'by Felix Modellbusse ;) (MoBu) 2019
Module Modifier
    Public Sub flipZ(Objekt As Local3DObjekt)
        With Objekt
            For i = 0 To .vertices.Count - 1 Step 3
                .vertices(i + 1) = - .vertices(i + 1)
            Next
        End With
        leftRightHanded(Objekt)
    End Sub

    Public Sub leftRightHanded(Objekt As Local3DObjekt)
        Dim F1alt As Integer
        Dim F3alt As Integer
        For Each subObjekt In Objekt.subObjekte
            For i = 0 To subObjekt.Count - 1 Step 3
                F1alt = subObjekt(i)
                F3alt = subObjekt(i + 2)

                subObjekt(i) = F3alt
                subObjekt(i + 2) = F1alt
            Next
        Next
    End Sub
End Module
