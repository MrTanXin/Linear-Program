using Google.OrTools.LinearSolver;

var solver = new Solver("SimpleLpProgram", Solver.OptimizationProblemType.GLOP_LINEAR_PROGRAMMING);

// Create the variables x1 x2 and x3 as ipod iPhone and iPad
var iPodProductNumber = solver.MakeNumVar(0.0, double.PositiveInfinity, "iPod");
var iPhoneProductNumber = solver.MakeNumVar(0.0, double.PositiveInfinity, "iPhone");
var iPadProductNumber = solver.MakeNumVar(0.0, double.PositiveInfinity, "iPad");

// Create Constraint c1 = (iPodProductNumber/7 + iPhoneProductNumber/5 + iPadProductNumber/3) <= 5
var c1 = solver.MakeConstraint(0, 5, "c1");
c1.SetCoefficient(iPodProductNumber, 1.0 / 7.0);
c1.SetCoefficient(iPhoneProductNumber, 1.0 / 5.0);
c1.SetCoefficient(iPadProductNumber, 1.0 / 3.0);

// Create Constraint c2 = (iPodProductNumber * 0.04 + iPhoneProductNumber * 0.055 + iPadProductNumber * 0.21) <= 6
var c2 = solver.MakeConstraint(0, 6, "c2");
c2.SetCoefficient(iPodProductNumber, 0.04);
c2.SetCoefficient(iPhoneProductNumber, 0.055);
c2.SetCoefficient(iPadProductNumber, 0.21);

// Create Constraint iPodProductNumber between 5 and 6
var c3 = solver.MakeConstraint(5, 6, "c3");
c3.SetCoefficient(iPodProductNumber, 1);

// Create Constraint iPhoneProductNumber between 0 and  15
var c4 = solver.MakeConstraint(0, 15, "c4");
c4.SetCoefficient(iPhoneProductNumber, 1);

    // Create Constraint iPadProductNumber between 6 and 8
var c5 = solver.MakeConstraint(6, 8, "c5");
c5.SetCoefficient(iPadProductNumber, 1);

// Create the Objective Function
// 4000* iPodProductNumber + 6000 * iPhoneProductNumber + 10000 * iPadProductNumber
var objective = solver.Objective();
objective.SetCoefficient(iPodProductNumber, 4000);
objective.SetCoefficient(iPhoneProductNumber, 6000);
objective.SetCoefficient(iPadProductNumber, 10000);
objective.SetOptimizationDirection(true);

Console.WriteLine(solver.ExportModelAsLpFormat(true));

// Export the Objective Function
solver.Solve();
Console.WriteLine("Solution:");
// Optimal objective value


Console.WriteLine("Objective value ={0}", objective.Value());
Console.WriteLine("iPod value ={0}", iPodProductNumber.SolutionValue());
Console.WriteLine("iPhone value ={0}", iPhoneProductNumber.SolutionValue());
Console.WriteLine("iPad value ={0}", iPadProductNumber.SolutionValue());

