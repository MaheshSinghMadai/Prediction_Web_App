
const PROXY_CONFIG = [
  {
    context: [
      "/Home",
    ],
    target : "https://localhost:7076",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
