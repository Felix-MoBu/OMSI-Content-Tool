Public Class OMSI_Body_osc
    Public distanceToCenter As Single
	Public frequenz As Point3D
	Public dämpfung As Point3D

	'The second entry defines the oscillating behaviour Of the car body:

	'[rail_body_osc]
	'{vertical moment arm between boogie pins And center of gravity of body}
	'{rotational oscilation around Y axle, angular frequency}
	'{rotational oscilation around Y axle, damping}
	'{rotational oscilation around X axle, angular frequency}
	'{rotational oscilation around X axle, damping}
	'{translational oscilation along Z axle, angular frequency}
	'{translational oscilation along Z axle, damping}

End Class
