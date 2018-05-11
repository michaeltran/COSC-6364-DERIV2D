# The following code generates the graphs of the functions A and B

cat("\014")

setwd(dirname(rstudioapi::getActiveDocumentContext()$path))
script.dir = getwd()
script.dir

# Load the following csv data generated from the C# code
COMPARE_DERIV_A_STATIC_1 = read.csv("COMPARE_DERIV_A_STATIC_1.csv")
COMPARE_DERIV_B_STATIC_1 = read.csv("COMPARE_DERIV_B_STATIC_1.csv")
COMPARE_DERIV_A_STATIC_2 = read.csv("COMPARE_DERIV_A_STATIC_2.csv")
COMPARE_DERIV_B_STATIC_2 = read.csv("COMPARE_DERIV_B_STATIC_2.csv")
COMPARE_DERIV_A_DYNAMIC_1 = read.csv("COMPARE_DERIV_A_DYNAMIC_1.csv")
COMPARE_DERIV_B_DYNAMIC_1 = read.csv("COMPARE_DERIV_B_DYNAMIC_1.csv")
COMPARE_DERIV_A_DYNAMIC_2 = read.csv("COMPARE_DERIV_A_DYNAMIC_2.csv")
COMPARE_DERIV_B_DYNAMIC_2 = read.csv("COMPARE_DERIV_B_DYNAMIC_2.csv")

Function_A = read.csv("DERIV2D_functionA_XY.csv", header = FALSE)
Function_dA = read.csv("DERIV_A.csv") 
Function_dA_Normalized = read.csv("DERIV_A_NORMALIZED.csv") 
Function_B = read.csv("DERIV2D_functionB_XY.csv", header = FALSE)

par(mfrow=c(1,1))
plot(Function_A$V1, Function_A$V2, main = "Function A", 
     type="l", xlab = "X", ylab = "Y")

plot(Function_dA$X, Function_dA$Y, main = "Derivative of Function A", 
     type="l", xlab = "X", ylab = "Y")

plot(Function_dA_Normalized$X, main = "Function A", 
     type="l", ylab = "X")

plot(Function_B$V1, Function_B$V2, main = "Function B", 
     type="l", xlab = "X", ylab = "Y")

par(mfrow=c(2,1))
plot(Function_B$V1, Function_B$V2, main = "Function B", 
     type="l", xlab = "X", ylab = "Y")
plot(COMPARE_DERIV_B_DYNAMIC_2$X, COMPARE_DERIV_B_DYNAMIC_2$Y, main = "Dynamic 2 - Function B", 
     type="l", xlab = "X", ylab = "Y")