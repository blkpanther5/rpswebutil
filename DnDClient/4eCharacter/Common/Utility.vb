Namespace Common

    ''' <summary>
    ''' Contains commonly used functions, enumerations and tools.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Utility

        ''' <summary>
        ''' Represents size class of object.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum SizeClass
            Tiny = 0
            Small = 1
            Medium = 2
            Large = 3
            Huge = 4
            Gargantuan = 5
            Colossal = 6
        End Enum

        ''' <summary>
        ''' Represents gender of creature.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum Gender
            Undefined = -1
            Male = 0
            Female = 1
        End Enum

        ''' <summary>
        ''' Represents alignment of creature.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum Alignment
            Good = 0
            Lawful_Good = 1
            Evil = 2
            Chaotic_Evil = 3
            Unaligned = 4
        End Enum

    End Class

End Namespace
