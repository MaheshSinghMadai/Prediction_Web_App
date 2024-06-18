import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HomeService } from '../../Services/home.service';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-fixture',
  templateUrl: './fixture.component.html',
  styleUrl: './fixture.component.css',
})
export class FixtureComponent implements OnInit {
  fixture_id: any;
  fixturesList: any = [];
  fixture: any = [];
  playersList: any = [];
  updateFixtureScoreForm: FormGroup;
  updateGoalScorerForm: FormGroup;

  constructor(
    private homeService: HomeService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
  ) {
    //form for updating score
    this.updateFixtureScoreForm = this.formBuilder.group({
      fixture_ID: ['', Validators.required],
      country1: ['', Validators.required],
      country1_score: ['', Validators.required],
      country2: ['', Validators.required],
      country2_score: ['', Validators.required],
    });

    //form for updating goal scorer
    this.updateGoalScorerForm = this.formBuilder.group({
      fixture_ID: this.fixture_id,
      goal_scorer: ['', Validators.required],
    });
  }
  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.fixture_id = params['fixture_ID'];
    });

    this.getFixtureById();
  }

  getFixtureById() {
    this.homeService.getFixtureById(this.fixture_id).subscribe(
      (response) => {
        this.fixture = response;
        // console.log(this.fixture);
        this.getPlayesrByFixture(
          this.fixture[0].country1,
          this.fixture[0].country2
        );
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getPlayesrByFixture(country1: string, country2: string) {
    this.homeService.getPlayersByFixture(country1, country2).subscribe(
      (response) => {
        this.playersList = response;
        // console.log(this.playersList);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  updateFixtureScore() {
    const body = {
      fixture_ID: this.fixture_id,
      country1: this.fixture[0].country1,
      country2: this.fixture[0].country2,
      country1_score: this.updateFixtureScoreForm.value['country1_score'],
      country2_score: this.updateFixtureScoreForm.value['country2_score'],
    };

    this.homeService.updateFixtureScore(body).subscribe(
      (response) => {
        // this.fixturesList = response;
        console.log(response);
        this.toastr.success('Score Updated Successfully');
        this.updateFixtureScoreForm.reset();
      },
      (error) => {
        console.log(error);
      }
    );
  }

  updateGoalScorer() {
    const selectedPlayer = this.updateGoalScorerForm.value['goal_scorer'];
    const body = {
      fixture_ID: this.fixture_id,
      player_ID: selectedPlayer.player_ID,
    };

    this.homeService.updateGoalScorer(body).subscribe(
      (response) => {
        this.toastr.success('Goal Scorer Updated Successfully');
        this.updateGoalScorerForm.reset();
        this.getFixtureById();
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
