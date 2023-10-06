# Task Manager

This app is a small application that allows users to report their daily, weekly, and monthly tasks. The project is developed using ASP.NET Core Web API and integrates with an SQL Server database. Additionally, it includes features such as Swagger documentation and JWT-based authentication.

![image](https://github.com/dilekkocaturk/Task-Manager/assets/88059253/d1ed13dc-9b72-421b-974b-89fddf692d02)

## JWT Authentication

This project utilizes JWT (JSON Web Token) for authentication and authorization purposes. Follow the steps below to obtain a JWT token:

### Retrieve JWT Token

To retrieve a JWT token, send a `GET` request to the following API endpoint:

![image](https://github.com/dilekkocaturk/Task-Manager/assets/88059253/7962490d-bee4-40d9-8ad6-da84a9ede9ba)

If the provided password is correct, the API will respond with a JWT token.
Example Response:

![image](https://github.com/dilekkocaturk/Task-Manager/assets/88059253/a20bfc51-5783-449e-a540-13b2f7fc257d)

### Include JWT Token in Requests

To access protected endpoints that require authentication, include the obtained JWT token in the `Authorization` header of subsequent API requests.

![image](https://github.com/dilekkocaturk/Task-Manager/assets/88059253/32cb7215-6305-4e7c-b7e6-c8661b7e8096)
![image](https://github.com/dilekkocaturk/Task-Manager/assets/88059253/7475177f-985a-4b44-ac46-85af6a522cad)

## Swagger Documentation

This app provides Swagger documentation for easy exploration and testing of the API endpoints.

- On the Swagger UI homepage, you will see an overview of the available API routes and methods. Click on a specific method to get more detailed information.

- Within the method page, you will find the required parameters, request body (if applicable) for making the API request. Fill in the necessary information.

- Click on the "Try it out" button to simulate the API request and see the response in real-time. Swagger UI provides a user-friendly interface for testing the API and viewing the results.

![image](https://github.com/dilekkocaturk/Task-Manager/assets/88059253/24843717-a8ec-4879-be36-a79fc8d727a0)


The screenshot above shows an example of the Swagger UI interface displaying the details of the first `GET` method. 
