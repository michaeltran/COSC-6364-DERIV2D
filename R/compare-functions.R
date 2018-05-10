# The following code generates the graphs from the raw data that was generated from the C# code

cat("\014")

setwd(dirname(rstudioapi::getActiveDocumentContext()$path))
script.dir = getwd()
script.dir

library(NISTunits)

# Default Colors for function A and B
plot_A_color = "#3CB371"
plot_B_color = "#F08080"

# Generates graphs for magnitude and degree comparisons
magnitude_degree_comparison <- function(Type, A, B) {
  A$Magnitude = sqrt(A$X^2 + A$Y^2)
  B$Magnitude = sqrt(B$X^2 + B$Y^2)
  
  A$Degree = NISTradianTOdeg(atan(A$Y/A$X))
  B$Degree = NISTradianTOdeg(atan(B$Y/B$X))
  
  #A$Degree = atan(A$Y/A$X)
  #B$Degree = atan(B$Y/B$X)
  
  magnitude_limit = c(min(A$Magnitude, B$Magnitude), max(A$Magnitude, B$Magnitude))
  magnitude_limit = c(min(A$Magnitude, B$Magnitude), 0.2)
  
  # Magnitude Comparison Graph
  plot(A$Magnitude, col = plot_A_color, main = paste(Type, "- Magnitude Comparison"), 
       type="l", xlab = "Index (Time)", ylab = "Vector Magnitude", ylim = magnitude_limit)
  lines(B$Magnitude, col = plot_B_color)
  legend("topright", legend=c("A", "B"),
         col=c(plot_A_color, plot_B_color), lty=1, cex=0.8, bg="transparent", box.lty=0)
  # Magnitude Difference Graph
  plot(B$Magnitude - A$Magnitude, main = paste(Type, "- Magnitude Difference B-A"), 
       type="l", xlab = "Index (Time)", ylab = "Difference in Vector Magnitude")
  
  # Degree Comparison Graph
  plot(A$Degree, col = plot_A_color, main = paste(Type, "- Degree Comparison"), 
       type="l", xlab = "Index (Time)", ylab = "Degree")
  lines(B$Degree, col = plot_B_color)
  legend("topright", legend=c("A", "B"),
         col=c(plot_A_color, plot_B_color), lty=1, cex=0.8, bg="transparent", box.lty=0)
  #Degree Difference Graph
  plot(B$Degree - A$Degree, main = paste(Type, "- Degree Difference B-A"), 
       type="l", xlab = "Index (Time)", ylab = "Difference in Degree")
}

# Generates graphs for by-axis comparisons (e.g. comparing X values or Y values)
by_axis_comparison <- function(Type, A, B) {
  # X Comparison Graph
  plot(A$X,type="l", col=plot_A_color, main = paste(Type, "- X Comparison"), 
      xlab = "Index (Time)", ylab = "X", ylim = c(-0.2,0.2))
  lines(B$X, col=plot_B_color)
  legend("topright", legend=c("A", "B"),
         col=c(plot_A_color, plot_B_color), lty=1, cex=0.8, bg="transparent", box.lty=0)
  # X Difference Graph
  plot(B$X - A$X, main = paste(Type, "- X Difference B-A"), 
       type="l", xlab = "Index (Time)", ylab = "Difference in X")
  
  # Y Comparison Graph
  plot(A$Y,type="l", col=plot_A_color, main = paste(Type, "- Y Comparison"), 
       xlab = "Index (Time)", ylab = "Y", ylim = c(-0.2,0.2))
  lines(B$Y, col=plot_B_color)
  legend("topright", legend=c("A", "B"),
         col=c(plot_A_color, plot_B_color), lty=1, cex=0.8, bg="transparent", box.lty=0)
  # Y Difference Graph
  plot(B$Y - A$Y, main = paste(Type, "- Y Difference B-A"), 
       type="l", xlab = "Index (Time)", ylab = "Difference in Y")
}

# Load the following csv data generated from the C# code
COMPARE_DERIV_A_STATIC_1 = read.csv("COMPARE_DERIV_A_STATIC_1.csv")
COMPARE_DERIV_B_STATIC_1 = read.csv("COMPARE_DERIV_B_STATIC_1.csv")
COMPARE_DERIV_A_STATIC_2 = read.csv("COMPARE_DERIV_A_STATIC_2.csv")
COMPARE_DERIV_B_STATIC_2 = read.csv("COMPARE_DERIV_B_STATIC_2.csv")
COMPARE_DERIV_A_DYNAMIC_1 = read.csv("COMPARE_DERIV_A_DYNAMIC_1.csv")
COMPARE_DERIV_B_DYNAMIC_1 = read.csv("COMPARE_DERIV_B_DYNAMIC_1.csv")
COMPARE_DERIV_A_DYNAMIC_2 = read.csv("COMPARE_DERIV_A_DYNAMIC_2.csv")
COMPARE_DERIV_B_DYNAMIC_2 = read.csv("COMPARE_DERIV_B_DYNAMIC_2.csv")

# Magnitude and Degree Graphs
#magnitude_degree_comparison("Static 1", COMPARE_DERIV_A_STATIC_1, COMPARE_DERIV_B_STATIC_1)
#magnitude_degree_comparison("Static 2", COMPARE_DERIV_A_STATIC_2, COMPARE_DERIV_B_STATIC_2)
#magnitude_degree_comparison("Dynamic 1", COMPARE_DERIV_A_DYNAMIC_1, COMPARE_DERIV_B_DYNAMIC_1)
#magnitude_degree_comparison("Dynamic 2", COMPARE_DERIV_A_DYNAMIC_2, COMPARE_DERIV_B_DYNAMIC_2)

# By-axis Graphs
by_axis_comparison("Static 1", COMPARE_DERIV_A_STATIC_1, COMPARE_DERIV_B_STATIC_1)
by_axis_comparison("Static 2", COMPARE_DERIV_A_STATIC_2, COMPARE_DERIV_B_STATIC_2)
by_axis_comparison("Dynamic 1", COMPARE_DERIV_A_DYNAMIC_1, COMPARE_DERIV_B_DYNAMIC_1)
by_axis_comparison("Dynamic 2", COMPARE_DERIV_A_DYNAMIC_2, COMPARE_DERIV_B_DYNAMIC_2)





