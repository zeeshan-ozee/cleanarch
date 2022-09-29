# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
  

##Auth
### Login
```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "firstname":"Aa",
    "lastname":"dd",
    "email":"ami@test",
    "password":"sdfsdfs"
}
```

#### Login Response

```json
{
    "firstname":"Aa",
    "lastname":"dd",
    "email":"ami@test",
    "password":"sdfsdfs"
}
```

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstname":"Aa",
    "lastname":"dd",
    "email":"ami@test",
    "password":"sdfsdfs"
}
```

#### Register Response

```json
{
    "firstname":"Aa",
    "lastname":"dd",
    "email":"ami@test",
    "password":"sdfsdfs"
}
```