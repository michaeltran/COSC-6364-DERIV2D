# COSC 6364 - Advanced Numerical Analysis - DERIV2D

Name: Hai-Y Michael Tran Nguyen

Email Address: michaeltranx@gmail.com

UH Email Address: mhtran4@uh.edu

UH ID: 0925358

---

## Details

The goal of this project is to extract derivatives and gradients of multidimensional functions and compare them. Specifically, we will numerically calculate the directional derivative of a Function A and compare it to another Function B (which is already the derivative). In this project, we will be doing this on 2D functions. 

---

## Implementation Details

Part 1 (DERIV2D) was developed in **.NET Core C#** using Microsoft Visual Studio 2018.

Part 2 was developed in **R** using R Studio.

---

## How to Build

To build the executable for Windows 10, open the DERIV2D.sln file in Microsoft Visual Studio 2018 and "publish" the application. (Right-Click the Solution in Solution Explorer in VS18 and click Publish, then in the "Publish" tab, click the "Publish" button)

The default publish location of the executable will be located in **"./DERIV2D/DERIV2D/bin\Release\netcoreapp2.0\win10-x64\publish"**.

---

## How to Run

	DERIV2D.exe path_to_function_A path_to_function_B output_directory

### Examples

	DERIV2D.exe "./DERIV2D_functionA_XY.csv" "./DERIV2D_functionB_XY.csv" "D:\SourceTree\cosc-6364-deriv2d\R"