Imports RolePlayingSystem.Data
Imports RolePlayingSystem.Data.SQL
Imports RolePlayingSystem.Data.SQL.Entities

Namespace Data.SQL
    Public Class RolePlayingSystem

#Region "Literals"

        Private _DB As Context.RolePlayingSystem

        Private _SQLConStr As String = Nothing

#End Region

#Region "Properties"

        ''' <summary>
        ''' Stores the global database context.
        ''' </summary>
        Protected Friend ReadOnly Property DB As Context.RolePlayingSystem
            Get
                Return _DB
            End Get
        End Property

        ''' <summary>
        ''' Containts intial connection string (for later reference).
        ''' </summary>
        Protected Friend ReadOnly Property SQLConStr As String
            Get
                Return _SQLConStr
            End Get
        End Property

#End Region

#Region "Events"

        ''' <summary>
        ''' Instantiates SQL data access class.
        ''' </summary>
        ''' <param name="ConnectionString">Connection string to connect to SQL database.</param>
        Public Sub New(ByVal ConnectionString As String)
            'Init the global context object on class instantiation.
            _DB = New Context.RolePlayingSystem(ConnectionString)

            'Set the connection string.
            _SQLConStr = ConnectionString
        End Sub

#End Region

#Region "Methods"

        ''' <summary>
        ''' Used to authenticate user against SQL database.
        ''' </summary>
        ''' <param name="Login">Login to match in account table.</param>
        ''' <param name="Password">Password to match login in account table.</param>
        ''' <returns>tblAccount row.</returns>
        Public Function getUserByCredentials(ByVal Login As String, _
                                             ByVal Password As String) As tblAccount

            'Query database for matching record.
            Try
                Dim Account = (From Q In _DB.tblAccounts _
                               Where Q.Login = Login And _
                               Q.Password = Password _
                               Select Q).SingleOrDefault()

                Return Account

            Catch ex As Exception
                'If error occurs, do nothing.
                Return Nothing

            End Try
        End Function

        ''' <summary>
        ''' Gets user by specified GUID.
        ''' </summary>
        ''' <param name="AccountId">GUID of record to retrieve.</param>
        ''' <returns>tblAccount row.</returns>
        Public Function getUserById(ByVal AccountId As String) As tblAccount

            'Query database for matching record.
            Try
                Dim Account = (From Q In _DB.tblAccounts _
                               Where Q.GUID = AccountId _
                               Select Q).SingleOrDefault()

                Return Account

            Catch ex As Exception
                'If error occurs, do nothing.
                Return Nothing

            End Try
        End Function

#End Region

    End Class
End Namespace
