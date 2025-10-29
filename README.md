# Business News App - ASP.NET Core MVC

## Team Members
- Member 1: Mude Jayaprakash
- Member 2: Pradeep
- Member 3: Kaylee Eckelman
- Member 4: Mythily

## Example of Web Page
![Uploading image.png…]()


## Description
This application fetches and displays top business headlines using NewsAPI. Built with ASP.NET Core MVC architecture.

## Prerequisites

### For Windows Users:
1. **.NET 9.0 SDK** - Download from: https://dotnet.microsoft.com/download
   - Download the `.exe` installer for Windows
   - Run the installer
   - Restart Command Prompt after installation
   - Verify installation: `dotnet --version`

2. **Git** (Optional but recommended) - Download from: https://git-scm.com/download/win

3. **Text Editor** - Visual Studio Code (recommended) or any text editor

### For Mac Users:
1. **.NET 9.0 SDK** - Download from: https://dotnet.microsoft.com/download
   - Or use Homebrew: `brew install --cask dotnet-sdk`
   - Verify installation: `dotnet --version`

2. **Git** - Usually pre-installed, or use: `brew install git`

---

## 🚀 Setup Instructions

### Step 1: Clone the Repository

**Open Command Prompt (Windows) or Terminal (Mac)**
```bash
# Clone the repository
git clone https://github.com/YOUR-USERNAME/BusinessNewsApp.git

# Navigate into the folder
cd BusinessNewsApp
```

### Step 2: Get Your NewsAPI Key

1. Go to: https://newsapi.org/register
2. Register with your USF email
3. Confirm your email (check spam folder)
4. Log in and copy your API key from the dashboard
5. **IMPORTANT:** Keep this key private!

### Step 3: Configure the API Key

**Open the file:** `appsettings.json`

**Find this section:**
```json
"NewsApi": {
  "ApiKey": "YOUR_API_KEY_HERE"
}
```

**Replace `YOUR_API_KEY_HERE` with your actual API key:**
```json
"NewsApi": {
  "ApiKey": "abc123def456ghi789"
}
```

**Save the file!**

⚠️ **IMPORTANT:** Each team member needs their own API key!

### Step 4: Restore Dependencies
```bash
dotnet restore
```

### Step 5: Run the Application
```bash
dotnet run
```

**You should see:**
```
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

### Step 6: View in Browser

**Open your browser and go to:**
```
http://localhost:5000/News
```

**You should see business news articles!**

---

## 🛑 How to Stop the Application

Press: `Ctrl + C` in the Command Prompt/Terminal

---

## 🔧 Troubleshooting

### Issue: "dotnet: command not found"

**Problem:** .NET SDK is not installed or not in PATH

**Solution:**
- **Windows:** 
  - Download from: https://dotnet.microsoft.com/download
  - Install the .exe file
  - Restart Command Prompt
  - Try: `dotnet --version`

- **Mac:**
  - `brew install --cask dotnet-sdk`
  - Or download from: https://dotnet.microsoft.com/download

---

### Issue: "API Key is missing in appsettings.json"

**Problem:** You didn't add your API key

**Solution:**
1. Open `appsettings.json`
2. Replace `YOUR_API_KEY_HERE` with your actual key
3. Save the file
4. Stop the app (Ctrl+C) and run again: `dotnet run`

---

### Issue: "BadRequest" or "Error fetching news"

**Problem:** API key is invalid or not activated

**Solution:**
1. Check your email for NewsAPI confirmation
2. Log in to https://newsapi.org and verify your key is active
3. Make sure there are no spaces in the API key in appsettings.json
4. Try a different endpoint - the code uses the "everything" endpoint which works on free tier

**Test your API key manually:**
Open browser and go to:
```
https://newsapi.org/v2/everything?q=business&language=en&apiKey=YOUR_KEY
```
Replace `YOUR_KEY` with your actual key. You should see JSON data.

---

### Issue: Port already in use

**Problem:** Port 5000 is being used by another application

**Solution:**
```bash
dotnet run --urls="http://localhost:3000"
```
Then open: `http://localhost:3000/News`

---

### Issue: Build errors or warnings

**Problem:** Cache or dependency issues

**Solution:**
```bash
dotnet clean
dotnet restore
dotnet build
dotnet run
```

---

## 📁 Project Structure
```
BusinessNewsApp/
├── Controllers/
│   └── NewsController.cs       # Handles API requests
├── Models/
│   └── NewsArticle.cs          # Data models
├── Views/
│   └── News/
│       └── Index.cshtml        # Display page
├── Program.cs                  # App configuration
├── appsettings.json           # Configuration (API key here!)
└── BusinessNewsApp.csproj     # Project file
```

---

## 🎯 Technologies Used

- ASP.NET Core 9.0
- C# MVC Pattern
- NewsAPI
- Bootstrap 5
- JSON Serialization

---

## 📸 Taking Screenshot for Submission

### Windows:
- Press: `Windows + Shift + S`
- Select the area
- Save as: `screenshot.png`

### Mac:
- Press: `Command + Shift + 4`
- Drag to select area
- Screenshot saves to Desktop

**Make sure to capture:**
- URL bar showing `localhost:5000/News`
- Page title
- At least 3-4 news articles
- Source, Title, and URL visible

---

## ⚠️ Important Notes

1. **API Key Security:** 
   - Never commit your API key to GitHub
   - Each team member uses their own key
   - Don't share your key publicly

2. **Free Tier Limits:**
   - 100 requests per day
   - Only works on localhost
   - Use the `/everything` endpoint (not `/top-headlines`)

3. **Development Only:**
   - This is a development project
   - Free API keys don't work in production

---

## 🆘 Still Having Issues?

1. Check that .NET 9.0 SDK is installed: `dotnet --version`
2. Make sure you're in the `BusinessNewsApp` folder
3. Verify your API key is correct in `appsettings.json`
4. Try the manual API test (see troubleshooting section)
5. Ask your team for help!

---


---

**Good luck! 🚀**
```

---

## 📝 STEP 2: Update .gitignore

Make sure your `.gitignore` file is correct to avoid committing build files:

**Check/Update:** `.gitignore`
```
## Ignore Visual Studio temporary files, build results, and
## files generated by popular Visual Studio add-ons.

# User-specific files
*.rsuser
*.suo
*.user
*.userosscache
*.sln.docstates

# Build results
[Dd]ebug/
[Dd]ebugPublic/
[Rr]elease/
[Rr]eleases/
x64/
x86/
[Ww][Ii][Nn]32/
[Aa][Rr][Mm]/
[Aa][Rr][Mm]64/
bld/
[Bb]in/
[Oo]bj/
[Ll]og/
[Ll]ogs/

# Visual Studio cache/options directory
.vs/

# Visual Studio Code
.vscode/

# .NET Core
project.lock.json
project.fragment.lock.json
artifacts/

# ASP.NET Scaffolding
ScaffoldingReadMe.txt

# NuGet Packages
*.nupkg
*.snupkg

# macOS
.DS_Store

# Don't commit the API key file (optional - only if you create a separate file)
