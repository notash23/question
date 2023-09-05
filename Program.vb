Imports System.IO

Module Program

    Dim queue(10) As node
    Dim head As Integer
    Dim tail As Integer
    Dim free As Integer

    Class node
        Public data As String
        Public nextNode As Integer
    End Class

    Sub Main(args As String())

    End Sub

    Sub initialise()
        Dim index As Integer
        For index = 1 To 10
            queue(index) = New node
            queue(1).nextNode = (index + 1)
        Next
        head = 0
        tail = 0
        free = 1
    End Sub

    Sub enqueue(data As String)
        If free = 0 Then
            Console.WriteLine("The queue is full")
            Return
        End If
        queue(free).data = data
        tail = free
        free = queue(free).nextNode
        Console.WriteLine("The data " + data + " has been added succesfully!")
    End Sub

    Sub output()
        Dim pointer As Integer
        pointer = head
        Do
            Console.Write(pointer + ": ")
            Console.WriteLine(queue(pointer).data)
        Loop Until pointer = tail
    End Sub

    Sub dequeue()
        If head = tail Then
            Console.WriteLine("The queue is empty")
            Return
        End If
        Console.WriteLine("The data removed is: " + queue(head).data)
        queue(head).data = ""
        head = queue(head).nextNode
    End Sub

    Sub readfromfile()
        Dim reader As StreamReader = New StreamReader("fruit.txt")
        If reader.EndOfStream Then
            Console.WriteLine("The file is empty!")
        End If
        While Not reader.EndOfStream
            enqueue(reader.ReadLine())
        End While
    End Sub

    Sub writetofile()
        Dim writer As StreamWriter = New StreamWriter("fruit.txt", FileMode.OpenOrCreate)
        Dim pointer As Integer
        pointer = head
        Do
            writer.WriteLine(queue(pointer).data)
            pointer = queue(pointer).nextNode
        Loop Until pointer = tail
    End Sub
End Module
