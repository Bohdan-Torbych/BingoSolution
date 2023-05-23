
# BingoSolution
This project is created to make easy to play bingo with your friends and other users!

### Here user is able to:
* Register/Login
* Set your game schedule
* Change privacy of user game schedule
* Make friends(send friends requests/accept friends requests)
* See geme schedule of your friends and public users

### Url card
#### Accounts managment
* [POST] /account/login - tryes to login user into system and return it, takes object with login data(email, password)
* [POST] /account/register - tryes to register user into system and return it, takes object with register data (full name, email, phone, etc...)
* [GET] /account/sign-out - tryes to sign-out user from system
#### Users managment
* [GET] /users - returns all users
* [GET] /users/friends - returns all users friends
* [GET] /users/friend-requests - returns all user's friends requests
* [POST] /users/friends - sends friend request, takes object with required data(friend username)
* [PATCH] /users/friends - accepts friend requests, takes object with required data(friend username)
#### Game schedule managment
* [GET] /game-schedule - returns all users sorted by game schedule
* [GET] /game-schedule/matches - returns all users that are matches with authorized user game schedule
* [POST] /game-schedule/matches - returns all users that are matches with the given date
* [PATCH] /game-schedule/update - sets game schedule of authorized user based on given object
* [PATCH] /game-schedule/update/{isPivate} - sets a game privacy of authorized user based on given value