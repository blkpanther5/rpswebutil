Namespace Character.Powers

    ''' <summary>
    ''' Named collection of all powers.
    ''' </summary>
    <Serializable()> _
    Public Class PowerCollection
        Inherits List(Of Power)

        Public Function AtWill() As IEnumerable(Of Power)
            Return Me.Where(Function(E) E.Type.ToLower() = "at-will")
        End Function

        Public Function Encounter() As IEnumerable(Of Power)
            Return Me.Where(Function(E) E.Type.ToLower() = "encounter")
        End Function

        Public Function Daily() As IEnumerable(Of Power)
            Return Me.Where(Function(E) E.Type.ToLower() = "daily")
        End Function

        Public Function Utility() As IEnumerable(Of Power)
            Return Me.Where(Function(E) E.Type.ToLower() = "utility")
        End Function

        Public Function LogicalSort() As IEnumerable(Of Power)
            Return AtWill.Concat(Encounter.Concat(Daily.Concat(Utility)))
        End Function
    End Class

End Namespace