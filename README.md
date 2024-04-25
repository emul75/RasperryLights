# RaspberryLights

## Description

RaspberryLights is a ASP.NET 8 web-based application that acts as the central control panel for the Raspberry Light System.  This application works in conjunction with the [RaspberryLightsDeviceWebApi](https://github.com/your-username/RaspberryLightsDeviceWebApi), a companion API that runs on Raspberry Pi and handles the direct control of WS2812B LED strips. The RaspberryLights web application is essential for managing device configurations and light animations, and it relies on the DeviceWebApi for execution of these configurations.

## Features

- **Dual-Component System**: Works alongside [RaspberryLightsDeviceWebApi](https://github.com/your-username/RaspberryLightsDeviceWebApi) to provide a complete lighting control solution.
- **Device Management**: Users can add, configure, and manage LED strips lightning control RaspberryPi devices.
- **Animation Control**: Customize and control light animations, adjusting parameters such as speed and brightness.

## Installation

### Prerequisites

- .NET 8 SDK
- Microsoft SQL Server

### Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/RaspberryLights.git
    ```
    
2. Navigate to the project directory:
    ```bash
    cd RaspberryLights
    ```
    
3. Install dependencies:
    ```bash
    dotnet restore
    ```
    
4. Set up your database connection string in appsettings.json. Replace the placeholders with your actual database details:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=your_database;User ID=your_username;Password=your_password;"
    }
    ```
5. Build and run the application:
    ```bash
    dotnet run
    ```

6. Usage

After installation, access the web interface by navigating to the URL where the application is hosted. Through the web interface, you can:

- Add New Devices: Via the "Add Device" menu.
- Edit Device Settings: Adjust settings and parameters for each device.
- Control Animations: Manage and deploy animations to connected devices.

### License

This project is made available for personal, non-commercial use only. Redistribution or commercial use is not permitted. All rights reserved.
