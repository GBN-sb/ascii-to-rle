Imports System.Console
Module Module1
    Sub Main()
        Dim responce As String
        Clear()
        WriteLine("1. Enter RLE")
        WriteLine("2. Display ASCII art")
        WriteLine("3. Convert to ascii art")
        WriteLine("4. Convert to RLE")
        WriteLine("5. Quit")
        responce = ReadLine()
        If responce = "1" Then
            enterRLE()
        ElseIf responce = "2" Then
            displayart()
        ElseIf responce = "3" Then
            WriteLine("convert to ascii art")
            RLEtoArt()
        ElseIf responce = "4" Then
            WriteLine("convert to rle")
            converttorle()
        ElseIf responce = "5" Then
            quit()
        Else
            Clear()
            WriteLine("Invalid input")
            Main()
        End If
    End Sub

    Sub quit()
        WriteLine("Press any key to quit")
        ReadKey()
        End
    End Sub

    Sub displayart()
        Dim location As String
        WriteLine("enter art")
        location = ReadLine()
        If validLocation(location) Then
            WriteLine(My.Computer.FileSystem.ReadAllText(location))
        Else
            Clear()
            WriteLine("Invalid file location")
            displayart()
        End If
        WriteLine("Press any button to return to menu")
        ReadKey()
        Main()
    End Sub

    Sub enterRLE()
        Dim noLines As String = 0
        Dim nolinesint As Integer
        Do
            Do
                WriteLine("Enter numbers of lines of rle")
                noLines = ReadLine()

            Loop Until intCheck(noLines) = True
            nolinesint = noLines - 1
        Loop Until noLines >= 2
        Dim conversion(noLines) As String
        Dim x = 0
        For i = 0 To nolinesint
            WriteLine("Enter: " & i + 1)
            Write(" line")
            conversion(x) = ReadLine().ToArray

        Next
        WriteLine(conversion(0))
        WriteLine("Press any Button to return to menu")
        ReadKey()
        Main()
    End Sub

    Sub RLEtoArt()

        Dim rle As String

        Dim location As String

        Do
            WriteLine("enter art")

            location = ReadLine()

        Loop Until validLocation(location) = True

        rle = My.Computer.FileSystem.ReadAllText(location)

        rle = rle + " "

        decompress(rle)

        WriteLine("Press any key to return to menu")

        ReadKey()
        Main()
    End Sub



    Sub converttorle()
        Dim art As String
        Dim location As String
        Do
            WriteLine("enter art")

            location = ReadLine()

        Loop Until validLocation(location) = True

        art = My.Computer.FileSystem.ReadAllText(location)

        art = art + " " ' Stops code from crashing when reaching the end of the string

        Dim artchar As Char() = art.ToCharArray 'converts from string to char

        Dim count As Integer = 0

        Dim letter As Char = artchar(0)



        For x = 0 To art.Length - 1

            If artchar(x) = letter Then

                count = count + 1 'Counts how many time the letter is used in a row 

            Else

                Write(addZeros(count) & letter)

                count = 1

                letter = artchar(x)

            End If

        Next
        WriteLine("Press any key to return to main menu")
        ReadKey()
        Main()

    End Sub



    Function addZeros(count)

        If count < 10 Then

            count = "0" & count

        End If

        Return count

    End Function





    Function intCheck(ByVal input As String) As Boolean

        If IsNumeric(input) Then
            Return True
        Else
            Return False
        End If

    End Function

    Function validLocation(ByVal location As String)
        Try 'Checks to see if the file location exists
            My.Computer.FileSystem.ReadAllText(location)
            Return True

        Catch ex As Exception
            WriteLine("Invalid file location")
            Return False
        End Try
    End Function

    Function decompress(ByVal line As String)

        Dim activeletter As String
        Dim firstint As Integer
        Dim secondint As Integer
        Dim doubleint As Integer
        Dim y As Integer = 0
        For x = 0 To line.Length

            firstint = Convert.ToInt32(line(y))
            If firstint = 32 Then
                WriteLine("complete")
                ReadKey()
                Main()
            Else
                If firstint = 13 Then
                    WriteLine()
                    y = y + 2
                Else
                    firstint = firstint - 48
                    secondint = Convert.ToInt32(line(y + 1))
                    secondint = secondint - 48
                    doubleint = (firstint & secondint)
                    activeletter = line(y + 2)
                    For h = 0 To doubleint - 1
                        Write(activeletter)

                    Next
                    y = y + 3
                End If
            End If
        Next


    End Function

End Module
