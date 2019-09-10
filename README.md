# UWPtesseract
UWP OCR app using .net Tesseract engine

## Installation
- clone the repo
- cd to uwptesseract directory
- copy the Tesseract directory to C:/Program Files
- In Explorer, navigate to C:/Program Files/Tesseract
- Right-click -> Properties
- Next, click the Security tab
- make sure the ALL_APPLICATIONS_PACKAGES group has read and excute permissions checked.  
- open UWPtesseract.sln in Visual Studio Community 2019
- build and depoly

## developer notes
### use .net tesseract engine 
to use the tessearct engine 3.05 in a UWP app, to to tools -> NuGet Package Manager -> Package Manager Console and run: Install-Package Tesseract -Version 3.3.0 
### calling the engine for mrz ocr: 

```cs
            IDictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("load_system_dawg", 0);
            dict.Add("load_freq_dawg", 0);
            dict.Add("load_unambig_dawg", 0);
            dict.Add("load_punc_dawg", 0);
            dict.Add("load_number_dawg", 0);
            dict.Add("load_fixed_length_dawgs", 0);
            dict.Add("load_bigram_dawg", 0);
            dict.Add("wordrec_enable_assoc", 0);
            dict.Add("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ<");


            var engine = new TesseractEngine(@"C:/Program Files/Tesseract/tessdata", "ocrb", EngineMode.Default, null, dict, false);
            var img = Pix.LoadFromFile(@"C:/Program Files/Tesseract/passport.jpg");
            var page = engine.Process(img);
...



