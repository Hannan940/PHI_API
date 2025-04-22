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

## Assumptions
The system only processes text files (.txt format). Any other file format is ignored.
When PHI is found, the system replaces the sensitive data with asterisks (**********),
The system is case-insensitive when identifying PHI information
Request and Processed files are for auditing purposes.
The system validates that the file is non-empty and contains content before processing.
The system handles errors, such as invalid file formats or issues during the reading

## Test Cases
1. Lowercase PHI: Input a file with all PHI content in lowercase letters.
```yaml
patient name: john doe
date of birth: 01/23/1980
social security number: 123-45-6789
address: 123 main st, anytown, usa
phone number: (555) 123-4567
email: john.doe@example.com
medical record number: mrn-0012345
order details:
- complete blood count (cbc)
- comprehensive metabolic panel (cmp)
```