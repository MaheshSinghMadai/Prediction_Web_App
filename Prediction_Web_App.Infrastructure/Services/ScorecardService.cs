using Microsoft.EntityFrameworkCore;
using Prediction_Web_App.Core.Entities;
using Prediction_Web_App.Infrastructure.Data;

namespace Prediction_Web_App.Infrastructure.Services
{
    public class ScorecardService
    {
        private readonly ApplicationDbContext _db;
        public ScorecardService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task UpdateScorecardsAsync(Fixture fixture)
        {
            //check if prediction is present
            var predictions = await _db.Predictions
                .Where(p => p.Fixture_ID == fixture.Fixture_ID)
                .ToListAsync();

            foreach (var prediction in predictions)
            {
                var scorecard = await _db.Scorecards
                    .FirstOrDefaultAsync(s => s.Fixture_ID == fixture.Fixture_ID && s.User_Id == prediction.User_Id);

                if (scorecard == null)
                {
                    scorecard = new Scorecard
                    {
                        Fixture_ID = fixture.Fixture_ID,
                        User_Id = prediction.User_Id
                    };
                    _db.Scorecards.Add(scorecard);
                }

                scorecard.Final_Score_Points = CalculateFinalScorePoints(fixture, prediction);
                scorecard.Goal_Scorer_Points = await CalculateGoalScorerPoints(fixture, prediction);
                scorecard.Total_Points = scorecard.Final_Score_Points + scorecard.Goal_Scorer_Points;

                //_db.Entry(scorecard).State = EntityState.Modified;
            }

            await _db.SaveChangesAsync();
        }

        //function to calculate score points
        private int CalculateFinalScorePoints(Fixture fixture, Prediction prediction)
        {
            int points = 0;
            if (fixture.Country1_Score == prediction.Country1_Score && fixture.Country2_Score == prediction.Country2_Score)
            {
                points += 20;
            }
            return points;
        }

        private async Task<int> CalculateGoalScorerPoints(Fixture fixture, Prediction prediction)
        {

            var fixtureWithGoalScorers = await _db.Fixtures
                                        .Include(f => f.Goal_Scorers)
                                        .FirstOrDefaultAsync(f => f.Fixture_ID == fixture.Fixture_ID);

            if (fixtureWithGoalScorers == null || prediction == null)
            {
                throw new ArgumentNullException(fixtureWithGoalScorers == null ? nameof(fixtureWithGoalScorers) : nameof(prediction));
            }
            int goalsScored = fixtureWithGoalScorers.Goal_Scorers.Count(gs => gs.Player_Id == prediction.Goal_Scorer_Id);

            int points = goalsScored * 10;

            return points;
        }
    }
}
