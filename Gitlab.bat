cd /d D:\FCI\SmartMotor
git init
git remote add origin https://gitlab.com/fci1/smartmotor.gi
git add .
git commit -m "Initial commit"
git checkout -b uat
git checkout -b sit
git checkout -b prd
git push -u origin master
git push -u origin uat
git push -u origin sit
git push -u origin prd
