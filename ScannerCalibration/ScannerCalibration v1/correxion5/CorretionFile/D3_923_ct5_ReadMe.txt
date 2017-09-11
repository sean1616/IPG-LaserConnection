	SCANLAB RTC 3D Correction File
	==============================

This ct5 correction file is calculated for a SCANLAB 3-axis scan system
for 3D image field correction. The ct5 format succeeds the ctb correction
file format, which is used with the RTC2 to RTC4. For further information
please refer to the RTC manual.


3D Correction File Parameters
-----------------------------

Filename:                     D3_923.ct5
Program Version:              3.11
Date:                         17.12.2013
Description:                  3D Correction File With F-Theta-Lens
varioSCAN Article Number:     123720
Scanning Lens:                120187
Evaluation Wavelength:        1064 nm

Scan Head Type:               hurry 20     
Scan Angle Calibration:       +/- 11.7 degrees mech.
XY-Swap:                      No

Scan Field Calibration K_xy:  3120 bit/mm
Scan Field Calibration K_z:   195 bit/mm
Max. Field Size (z=0):        336.082 mm
Max. Z-Range:                 +/- 78.0 mm
Max. Field Size (z=max):      292.828 mm
Max. X-/Y-Coordinate Value:   456811 bit

X Stretch-Factor (0 = telecentric):  0.00165
Y Stretch-Factor (0 = telecentric):  0.0015
Reference Point:                     (0,0,8.60942) mm
(focus shifter in neutral position)

dl (max. z Control Value +32767):    88.270 mm
dl (min. z Control Value -32767):    -70.440 mm
Max. Scan Angle Mirror 1:            11.449 degrees mech.
Max. Scan Angle Mirror 2:            12.125 degrees mech.

Polynomial Coefficients for Focus Shift Control:
Focus Shift = ds (directed from z=0 opposite to z)
Control Value = A + B*ds*K_z + C*(ds*K_z)^2
A = 3602.08
B = 2.11944
C = -1.55702e-005

Polynomial Coefficients for Distortion Correction:
Image Height = f1*theta + f2*theta^2 + f3*theta^3 + f4*theta^4
Scan Angle = theta
f1 = 420.456 mm
f2 = -6.051 mm
f3 = 37.397 mm
f4 = -55.240 mm

