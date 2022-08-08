### Buber Dinner API

tabe of contents(up to date)

- [Buber Dinner API](#buber-dinner-api)
- [Auth](#auth)
- [Register](#register)
- [Register Request](#register-request)
- [Register Response](#register-response)
- [Login](#login)
- [Login request](#login-request)
- [Login Response](#login-response)

### Auth

### Register

```js
POST {{host}}/auth/register
```

### Register Request

```json
{
    "firstName": "Amichai",
    "lastName": "Mantinband",
    "email": "amichai@gmail.com",
    "password": "amichi12@"
}
```
### Register Response
```js
200 OK
```
```json
{
    "id": "d89c29a-eb3e-4075-95ff-b92055aa104",
    "firstName": "Amichai",
    "lastName": "Mantinband",
    "email": "amichai@gmail.com",
    "token": "eyJhb..hbbQ"
}
```
### Login

### Login request

### Login Response

```json
{
    "id": "d89c29a-eb3e-4075-95ff-b92055aa104",
    "firstName": "Amichai",
    "lastName": "Mantinband",
    "email": "amichai@gmail.com",
    "token": "eyJhb..hbbQ"
}
```





