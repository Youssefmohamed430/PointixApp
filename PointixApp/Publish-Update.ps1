# إعداد المتغيرات
$AppName = "PointixApp"
$Version = "1.0.0"
$ReleaseNotes = "Initial release"
$GitHubRepo = "Youssefmohamed430/PointixApp"

# 1. توليد حزمة Squirrel
dotnet build -c Release
Squirrel --releasify .\bin\Release\$AppName-$Version.nupkg

# 2. الدخول إلى GitHub (أول مرة بس)
gh auth login

# 3. إنشاء إصدار جديد ورفع الملفات
gh release create "v$Version" .\Releases\* `
  --repo $GitHubRepo `
  --title "v$Version" `
  --notes "$ReleaseNotes"

Write-Host "تم رفع التحديث إلى GitHub Releases."
