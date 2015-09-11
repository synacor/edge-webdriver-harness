# edge-webdriver-harness
A simple program to loop over sites and take screenshots via the Edge WebDriver.

## requirements
* Running Windows 10
* Install the [Edge WebDriver](https://www.microsoft.com/en-us/download/details.aspx?id=48212)

## how to use
* Run EdgeWebDriverHarness.exe
* Modify the `config.json` that is created to specify what sites and pages to run against
  * Windows style paths with `\` in them must be escaped (i.e. `C:\\Selenium\\Screenshots`)
  * Note that if you modify the `config.json` be sure to back it up before overwriting it with a new version

## how to modify
* Open EdgeWebDriverHarness.sln in [Visual Studio 2015 Community Edition](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* `Program.cs` will be where the actual controls happen
* The `Models` directory contains the classes related to the `config.json` file
* Once everything is changed how you want it, Go to `Build` > `Build Solution`
* You can find your files in the `bin` directory of the project then.