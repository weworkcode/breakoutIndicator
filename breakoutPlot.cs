DEF   SUPPORT2 = low;
 DEF   MIN = Min(open, close);

declare upper;

input HideBalance = no;

input HideBoxLines = no;

input HideCloud = no;

input BarsUsedForRange = 5;

input BarsRequiredToRemainInRange = 7;

# Identify Consolidation

def MINMIN = lowest(MIN[1], BarsUsedForRange);

def SUPPORT2L = lowest(SUPPORT2[1], BarsUsedForRange);

def maxMIN = lowest(MINMIN, BarsRequiredToRemainInRange);

def maxSUPPORT2 = lowest(SUPPORT2L, BarsRequiredToRemainInRange);

def MINn = if maxMIN == maxMIN[1] or maxSUPPORT2 == maxSUPPORT2 then maxMIN else MINn[1];

def SUPPORT2n = if maxMIN == maxMIN[1] or maxSUPPORT2 == maxSUPPORT2 then maxSUPPORT2 else SUPPORT2n[1];

def Bh = if MIN >= MINn and MINn == MINn[1] then MINn else double.nan;

def Bl = if SUPPORT2 >= SUPPORT2n and SUPPORT2n == SUPPORT2n[1] then SUPPORT2n else double.nan;


def CountH = if isnan(Bh) or isnan(Bl) then 2 else CountH[1] + 1;

def CountL = if isnan(Bh) or isnan(Bl) then 2 else CountL[1] + 1;

def ExpH = if barnumber() == 1 then double.nan else

            if CountH[-BarsRequiredToRemainInRange] >= BarsRequiredToRemainInRange then MINn[-BarsRequiredToRemainInRange] else

            if MIN >= ExpH[1] then ExpH[1] else double.nan;

def ExpL = if barnumber() == 1 then double.nan else

            if Countl[-BarsRequiredToRemainInRange] >= BarsRequiredToRemainInRange then SUPPORT2n[-BarsRequiredToRemainInRange] else

            if SUPPORT2 >= ExpL[1] then ExpL[1] else double.nan;

# Plot the High and Low of the Box; Paint Cloud

plot BoxHigh = if !isnan(expL) and !isnan(ExpH) then ExpH else double.nan;

plot BoxLow = if !isnan(expL) and !isnan(ExpH) then ExpL else double.nan;

boxhigh.setdefaultColor(color.dark_RED);

BoxHigh.setpaintingStrategy(paintingStrategy.HORIZONTAL);

BoxLow.setpaintingStrategy(paintingStrategy.HORIZONTAL);

BoxLow.setdefaultColor(color.LIGHT_GREEN );

BoxHigh.SETHIDING(HideBoxLines);

BoxLow.SETHIDING(HideBoxLines);
BOXHigh.SetLineWeight(3);
BOXLOW.SetLineWeight(3);
addcloud(if !HideCloud then BoxHigh else double.nan, BoxLow, color.LIGHT_GREEN , color.LIGHT_GREEN );

# Things to the Right of a Finished Box

def eH = if barnumber() == 1 then double.nan else if !isnan(BoxHigh[1]) and isnan(BoxHigh) then BoxHigh[1] else eh[1];

def eL = if barnumber() == 1 then double.nan else if !isnan(BoxLow[1]) and isnan(BoxLow) then BoxLow[1] else el[1];

plot Balance = if isnan(boxhigh) and isnan(boxlow) then (eh+el)/2 else double.nan;

Balance.SETHIDING(HideBalance);

Balance.setdefaultColor(COLOR.LIGHT_GREEN );

Balance.setpaintingStrategy(PAIntingStrategy.SQUARES);

plot RH = (balance *2)-el  ;
plot RL =  (balance *2)-eh  ;



addcloud(if !HideCloud then rh else double.nan, rl, color.GRAY, color.GRAY);


rh.setdefaultColor(color.DARK_red);
rh.setpaintingStrategy(paintingStrategy.HORIZONTAL);
rl.setdefaultColor(color.DARK_green);
rl.setpaintingStrategy(paintingStrategy.HORIZONTAL);
RH.SetLineWeight(3);
RL.SetLineWeight(3);


##############################################################

 DEF   H = high;
 DEF   max = Max(open, close);


# Identify Consolidation

def HH1 = highest(h[1], BarsUsedForRange);
def LL1 = highest(max[1], BarsUsedForRange);
def maxH1 = highest(hh1, BarsRequiredToRemainInRange);
def maxL1 = highest(ll1, BarsRequiredToRemainInRange);

def HHn1 = if maxH1 == maxH1[1] or maxL1 == maxL1 then maxH1 else HHn1[1];

def LLn1 = if maxH1 == maxH1[1] or maxL1 == maxL1 then maxL1 else LLn1[1];

def Bh1 = if h <= HHn1 and HHn1 == HHn1[1] then HHn1 else double.nan;

def Bl1 = if max <= LLn1 and LLn1 == LLn1[1] then LLn1 else double.nan;

def CountH1 = if isnan(Bh1) or isnan(Bl1) then 2 else CountH1[1] + 1;

def CountL1 = if isnan(Bh1) or isnan(Bl1) then 2 else CountL1[1] + 1;

def ExpH1 = if barnumber() == 1 then double.nan else

            if CountH1[-BarsRequiredToRemainInRange] >= BarsRequiredToRemainInRange then HHn1[-BarsRequiredToRemainInRange] else

            if H <= ExpH1[1] then ExpH1[1] else double.nan;

def ExpL1 = if barnumber() == 1 then double.nan else

            if Countl1[-BarsRequiredToRemainInRange] >= BarsRequiredToRemainInRange then LLn1[-BarsRequiredToRemainInRange] else

            if max <= ExpL1[1] then ExpL1[1] else double.nan;


# Plot the High and Low of the Box; Paint Cloud

plot BoxHigh1 = if !isnan(expL1) and !isnan(ExpH1) then ExpH1 else double.nan;


plot BoxLow1 = if !isnan(expL1) and !isnan(ExpH1) then ExpL1 else double.nan;

boxhigh1.setdefaultColor(color.dark_RED);

BoxHigh1.setpaintingStrategy(paintingStrategy.HORIZONTAL);

BoxLow1.setpaintingStrategy(paintingStrategy.HORIZONTAL);

BoxLow1.setdefaultColor(color.dark_GREEN);

BoxHigh1.SETHIDING(HideBoxLines);

BoxLow1.SETHIDING(HideBoxLines);
BOXHigh1.SetLineWeight(3);
BOXLOW1.SetLineWeight(3);
addcloud(if !HideCloud then BoxHigh1 else double.nan, BoxLow1, color.pink, color.pink);

# Things to the Right of a Finished Box

def eH1 = if barnumber() == 1 then double.nan else if !isnan(BoxHigh1[1]) and isnan(BoxHigh1) then BoxHigh1[1] else eh1[1];

def eL1 = if barnumber() == 1 then double.nan else if !isnan(BoxLow1[1]) and isnan(BoxLow1) then BoxLow1[1] else el1[1];


plot Balance1 = if isnan(boxhigh1) and isnan(boxlow1) then (eh1+el1)/2 else double.nan;

Balance1.SETHIDING(HideBalance);

Balance1.setdefaultColor(COLOR.PINK);

Balance1.setpaintingStrategy(PAIntingStrategy.SQUARES);

plot RH1 = (balance1 *2)-el1  ;
plot RL1 =  (balance1 *2)-eh1  ;



addcloud(if !HideCloud then rh1 else double.nan, rl1, color.GRAY, color.GRAY);


rh1.setdefaultColor(color.DARK_red);
rh1.setpaintingStrategy(paintingStrategy.HORIZONTAL);
rl1.setdefaultColor(color.DARK_green);
rl1.setpaintingStrategy(paintingStrategy.HORIZONTAL);
RH1.SetLineWeight(3);
RL1.SetLineWeight(3);
