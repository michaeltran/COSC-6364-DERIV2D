# The following code generates the graphs of the functions A and B

cat("\014")

setwd(dirname(rstudioapi::getActiveDocumentContext()$path))
script.dir = getwd()
script.dir

Function_A = read.csv("DERIV2D_functionA_XY.csv", header = FALSE)
Function_dA = read.csv("DERIV_A.csv") 
Function_B = read.csv("DERIV2D_functionB_XY.csv", header = FALSE)

plot(Function_A$V1, Function_A$V2, main = "Function A", 
     type="l", xlab = "X", ylab = "Y")

plot(Function_dA$X, Function_dA$Y, main = "Derivative of Function A", 
     type="l", xlab = "X", ylab = "Y")

plot(Function_B$V1, Function_B$V2, main = "Function B", 
     type="l", xlab = "X", ylab = "Y")