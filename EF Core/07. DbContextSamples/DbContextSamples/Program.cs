﻿using DbContextSamples;
MyDbContext context = new();
SampleSources sample = new(context);
sample.AddStudnet("Using Interceptors");
Console.WriteLine("Press any key to exit ...");
Console.ReadLine();