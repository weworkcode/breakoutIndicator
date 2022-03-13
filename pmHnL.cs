declare once_per_bar;

input PlotPreMktLinesHrsPastOpen = yes;
input ShowChartBubbles = yes;

def bar = BarNumber();
def nan = Double.NaN;
def vHigh = high;
def vLow = low;

def PMhrs = RegularTradingStart (GetYYYYMMDD()) > GetTime();
def RMhrs = RegularTradingStart (GetYYYYMMDD()) < GetTime();
def PMStart = RMhrs[1] and PMhrs;
def PMHigh = CompoundValue(1, if PMStart then vHigh else if PMhrs then Max(vHigh, PMHigh[1]) else PMHigh[1], 0);
def PMLow = CompoundValue(1, if PMStart then vLow else if PMhrs then Min(vLow, PMLow[1]) else PMLow[1], 0);
def highBar = if PMhrs and vHigh == PMHigh then bar else nan;
def lowBar = if PMhrs and vLow == PMLow then bar else nan;
def PMHighBar = if bar == HighestAll(highBar) then PMHigh else PMHighBar[1];
def PMLowBar = if bar == HighestAll(lowBar) then PMLow else PMLowBar[1];

plot PMH =  if PlotPreMktLinesHrsPastOpen and PMHighBar != 0
            then PMHighBar
            else nan;
plot PML =  if PlotPreMktLinesHrsPastOpen and PMLowBar != 0
            then PMLowBar
            else nan;
plot PMMid = if PlotPreMktLinesHrsPastOpen and PMHighBar != 0 and PMLowBar != 0
             then (PMHighBar + PMLowBar) / 2
             else nan;

AddChartBubble(ShowChartBubbles and bar == HighestAll(highBar),
  PMHigh,
  "PM High",
  Color.Gray,
  1);

AddChartBubble(ShowChartBubbles and bar == HighestAll(lowBar),
  PMLow,
  "PM Low",
  Color.Gray,
  0);

AddChartBubble(ShowChartBubbles and bar == Max(HighestAll(highBar), HighestAll(lowBar)),
  (PMHighBar + PMLowBar) / 2,
  "PM Mid",
  Color.Gray,
  1);

# end of script
