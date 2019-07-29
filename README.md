# wakatime-noncoding
an Electron app to track not coding related work

## How to use
1. clone repo
2. get yourself a wakatime app id and an app secret
3. add http://localhost:5000/auth to the Redirect Urls of the app
4. goto the app and insert your app id and secret in the backend code (src/api/controllers/authController.cs line 25 to 30)
5. goto the app and insert your app id in the frontend code (src/app/index.html line 40)
5. open terminal or shell or whatever and run either the run.bat file or run.sh file - this will build the electron app to the dist folder

## Disclaimer
This app is an one hour work. It's far away from beeing pretty. I never tried the app on windows. It should work though
