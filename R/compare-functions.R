cat("\014")

setwd(dirname(rstudioapi::getActiveDocumentContext()$path))
script.dir = getwd()
script.dir

COMPARE_DERIV_A = read.csv("COMPARE_DERIV_A_STATIC_1.csv")
COMPARE_DERIV_B = read.csv("COMPARE_DERIV_B_STATIC_1.csv")

plot(COMPARE_DERIV_A$X, main = "Derivative of A - X")
plot(COMPARE_DERIV_B$X, main = "Derivative of B - X")

plot(COMPARE_DERIV_A$X - COMPARE_DERIV_B$X, main = "Derivative of A-B - X")
