﻿Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Net
Imports RolePlayingSystem.Common.Net

Namespace Common

    ''' <summary>
    ''' Contains commonly used functions, enumerations and tools.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Utility

#Region "Enumerations"

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

#End Region

#Region "Methods"

        ''' <summary>
        ''' Performs simple check for null attributes.
        ''' </summary>
        ''' <param name="Attribute">XAttribute to check.</param>
        ''' <returns>Object value of supplied attribute.</returns>
        Shared Function getAttributeValue(ByVal Attribute As XAttribute) As Object
            'First check if the attribute is valid.
            If Attribute Is Nothing Then _
                Return Nothing

            'Ok, now return the attribute value.
            Return Attribute.Value
        End Function

#End Region

    End Class

End Namespace
