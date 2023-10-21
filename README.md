# Nobel Project API

## Introduction

The Nobel Project API is a backend service for a Rock-Paper-Scissors game with player registration and authentication capabilities. This API allows users to play games, view statistics, register, and log in. It serves as the backend for the Nobel Project game application.

## Features

- **Rock-Paper-Scissors Game**: Users can play the classic Rock-Paper-Scissors game against the computer.
- **Player Registration**: Players can register for the game by providing a username and password.
- **Player Authentication**: Registered players can log in and receive an authentication token.
- **Game Statistics**: Players can view their game statistics, including wins, losses, and ties.

## Getting Started

### Prerequisites

Before you start, make sure you have the following:

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) installed.
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) for database migrations.
- A PostgreSQL database for the API data.

### Installation

 Clone the repository:

   ```bash
   git clone https://github.com/your-username/nobel-project-api.git
   cd nobel-project-api
   ```

## API Endpoints

### Game Controller
The `GameController` provides endpoints for managing the Rock-Paper-Scissors game:

- **POST /api/game/start**: Start a new game.
- **POST /api/game/play**: Play a move in an ongoing game.
- **POST /api/game/terminate**: Terminate an ongoing game.
- **GET /api/game/statistics/{id}**: Get player statistics.

### Player Controller
The `PlayerController` manages player registration and authentication:

- **POST /api/player/register**: Register a new player.
- **POST /api/player/login**: Log in and receive an authentication token.
- **GET /api/player/{id}**: Get player details by ID.
- **GET /api/player/search/{username}**: Search for a player by username.

## Authentication

The API uses JSON Web Tokens (JWT) for player authentication. Players can register, log in, and receive a JWT token that is required for accessing authenticated endpoints.

## Contributing

We welcome contributions to enhance this API. Here's how you can get involved:

1. **Fork the repository.**
   - Create your own fork of the project by clicking the "Fork" button on the top-right corner of this repository page.

2. **Create a new branch for your feature or bug fix:**
   - Before you start working on a new feature or fixing a bug, create a new branch that will contain your changes. Naming it appropriately, like `git checkout -b feature/your-feature-name`, is a good practice.

3. **Make your changes and commit them:**
   - Implement the changes and commit them using descriptive commit messages, e.g., `git commit -m 'Add a new feature'`.

4. **Push to the branch:**
   - Push your changes to the branch you created: `git push origin feature/your-feature-name`.

5. **Create a pull request to submit your changes:**
   - Open a pull request (PR) in the original repository. This is the process of requesting that your changes be merged into the main project. 

We appreciate your contributions and look forward to your ideas and enhancements.

