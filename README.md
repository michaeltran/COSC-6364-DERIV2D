# COSC 6364 - Advanced Numerical Analysis - DERIV2D

Name: Hai-Y Michael Tran Nguyen

Email Address: michaeltranx@gmail.com

UH Email Address: mhtran4@uh.edu

UH ID: 0925358

---

## Details

The goal of this project is to extract derivatives and gradients of multidimensional functions and compare them. Specifically, we will numerically calculate the directional derivative of a Function A and compare it to another Function B (which is already the derivative). In this project, we will be doing this on 2D functions. 

---

## Important Files and Locations

Report: Report.doc/Report.pdf
Source Code (Part 1): DERIV2D
Source Code (Part 2): R
Pre-built Executable: DERIV2D-Executable\DERIV2D
Readme: README.md
Powerpoint: Final Project Presentation - DERIV2D.pptx (includes audio from video presentation)
Video Presentation: Final Project Presentation - DERIV2D.mp4

Input: DERIV2D_functionA_XY.csv, DERIV2D_functionB_XY.csv

---

## Implementation Details

The project is split up into two parts:

Part 1 (DERIV2D) was developed in **.NET Core C#** using Microsoft Visual Studio 2018.

Part 2 was developed in **R** using R Studio.

---

## How to Build

### Part 1

To build the executable for Windows 10, open the DERIV2D.sln file in Microsoft Visual Studio 2018 and "publish" the application. (Right-Click the Solution in Solution Explorer in VS18 and click Publish, then in the "Publish" tab, click the Publish button)

The default publish location of the executable will be located in **".\DERIV2D\DERIV2D\bin\Release\netcoreapp2.0\win10-x64\publish"**.

### Part 2

To run part 2, **put the output from Part 1 into the "R" folder** and then navigate to the "R" folder and open "compare-functions.R" and "plot_basic_graphs.R" in R Studio. Clear environment data and then run the entire source code in both files.

This will generate the plots used in the report.

---

## How to Run

	DERIV2D.exe path_to_function_A path_to_function_B output_directory

### Examples

	DERIV2D.exe "./DERIV2D_functionA_XY.csv" "./DERIV2D_functionB_XY.csv" "D:\SourceTree\cosc-6364-deriv2d\R"