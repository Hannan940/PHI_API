# PHI API

## Overview

The PHI API is designed to redact Protected Health Information (PHI) from text files (.txt format). This service processes uploaded files, removes sensitive PHI, and saves both the original and redacted versions of the file. The service also tracks all redacted items for auditing purposes, ensuring compliance with data privacy regulations.

---

## Prerequisites

Before setting up the project, ensure you have the following tools installed:

- **Visual Studio 2022**
- **.NET 6.0 or later**
---

## Project Setup in Visual Studio 2022

### Step 1: Clone the Repository

### Step 2: Open the Project in Visual Studio

## Configuration

Ensure that the `appsettings.json` file is correctly configured. This file contains important configurations such as file paths for saving the original and redacted files, as well as the allowed file formats.

Example configuration in `appsettings.json`:

```json
{
  "PHIConfig": {
    "RequestsDirectoryPath": "C:\\Files\\Requests",
    "SanitizedDirectoryPath": "C:\\Files\\Sanitized",
    "ValidFormats": [".txt"]
  }
}
```
