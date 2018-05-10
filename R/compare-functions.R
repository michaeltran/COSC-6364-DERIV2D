cat("\014")

setwd(dirname(rstudioapi::getActiveDocumentContext()$path))
script.dir = getwd()
script.dir

plot_A_color = "#F08080"
plot_B_color = "#3CB371"

comparisons <- function(Type, A, B) {
  A$Magnitude = sqrt(A$X^2 + A$Y^2)
  B$Magnitude = sqrt(B$X^2 + B$Y^2)
  
  yLimits = c(min(A$Magnitude, B$Magnitude), max(A$Magnitude, B$Magnitude))
  yLimits = c(min(A$Magnitude, B$Magnitude), 0.2)
  
  plot(A$Magnitude, col = plot_A_color, main = paste(Type, "- pythag Magnitude Comparison"), type="l", ylab = "", ylim = yLimits)
  lines(B$Magnitude, col = plot_B_color)
  
  legend("topright", legend=c("A", "B"),
         col=c(plot_A_color, plot_B_color), lty=1, cex=0.8, bg="transparent", box.lty=0)
}


COMPARE_DERIV_A_STATIC_1 = read.csv("COMPARE_DERIV_A_STATIC_1.csv")
COMPARE_DERIV_B_STATIC_1 = read.csv("COMPARE_DERIV_B_STATIC_1.csv")
COMPARE_DERIV_A_STATIC_2 = read.csv("COMPARE_DERIV_A_STATIC_2.csv")
COMPARE_DERIV_B_STATIC_2 = read.csv("COMPARE_DERIV_B_STATIC_2.csv")
COMPARE_DERIV_A_DYNAMIC_1 = read.csv("COMPARE_DERIV_A_DYNAMIC_1.csv")
COMPARE_DERIV_B_DYNAMIC_1 = read.csv("COMPARE_DERIV_B_DYNAMIC_1.csv")
COMPARE_DERIV_A_DYNAMIC_2 = read.csv("COMPARE_DERIV_A_DYNAMIC_2.csv")
COMPARE_DERIV_B_DYNAMIC_2 = read.csv("COMPARE_DERIV_B_DYNAMIC_2.csv")

comparisons("Static 1", COMPARE_DERIV_A_STATIC_1, COMPARE_DERIV_B_STATIC_1)
comparisons("Static 2", COMPARE_DERIV_A_STATIC_2, COMPARE_DERIV_B_STATIC_2)
comparisons("Dynamic 1", COMPARE_DERIV_A_DYNAMIC_1, COMPARE_DERIV_B_DYNAMIC_1)
comparisons("Dynamic 2", COMPARE_DERIV_A_DYNAMIC_2, COMPARE_DERIV_B_DYNAMIC_2)







plot(COMPARE_DERIV_A_STATIC_1$X,type="l",col=plot_B_color, ylim = c(-0.2,0.7), main = "X Comparison")
lines(COMPARE_DERIV_B_STATIC_1$X,col=plot_A_color)

plot(COMPARE_DERIV_A_STATIC_1$Y,type="l",col=plot_B_color, ylim = c(-0.2,0.7), main = "Y Comparison")
lines(COMPARE_DERIV_B_STATIC_1$Y,col=plot_A_color)


plot(COMPARE_DERIV_A_STATIC_1$X, main = "Derivative of A - X", type="l", ylab = "X")
plot(COMPARE_DERIV_B_STATIC_1$X, main = "Derivative of B - X", type="l", ylab = "X")

plot(COMPARE_DERIV_A_STATIC_1$X - COMPARE_DERIV_B_STATIC_1$X, main = "Derivative of A-B - X", type="l",  ylab = "X-X")




COMPARE_DERIV_A_STATIC_1$X - COMPARE_DERIV_B_STATIC_1$X


#sqrt(COMPARE_DERIV_A_STATIC_1$X^2 + COMPARE_DERIV_B_STATIC_1$X^2)

comparisons(COMPARE_DERIV_A_STATIC_1, COMPARE_DERIV_B_STATIC_1)
