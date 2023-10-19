Imports System.Drawing
Imports System.IO
Imports Tesseract

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submitFile_ServerClick(sender As Object, e As EventArgs)
        Try
            Dim texto As String
            If imageFile.PostedFile IsNot Nothing Then
                'Guardar la imagen
                Dim inputStream As Stream = imageFile.PostedFile.InputStream
                Dim rutaDestino As String = Server.MapPath("~/img/texto.jpg")
                Dim outputStream As New FileStream(rutaDestino, FileMode.Create)

                Dim buffer(4096) As Byte
                Dim bytesRead As Integer
                Do
                    bytesRead = inputStream.Read(buffer, 0, buffer.Length)
                    If bytesRead > 0 Then
                        outputStream.Write(buffer, 0, bytesRead)
                    End If
                Loop While bytesRead > 0

                ' Cierra los flujos de entrada y salida
                inputStream.Close()
                outputStream.Close()

                'Leer el archivo y mostrar el texto
                Using engine = New TesseractEngine(Server.MapPath("~/tessdata"), "spa", EngineMode.Default)
                    Using img = Pix.LoadFromFile(rutaDestino)
                        Using page = engine.Process(img)
                            texto = page.GetText()
                            meanConfidenceLabel.InnerText = String.Format("{0:P}", page.GetMeanConfidence())
                            resultText.InnerText = page.GetText()
                        End Using
                    End Using
                End Using
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub bitMap_ServerClick(sender As Object, e As EventArgs)
        Try
            'CONVERTIR A BITMAP
            Dim inputStream As Stream = imageFile.PostedFile.InputStream
            Dim bitmap As New Bitmap(inputStream)

            Using engine = New TesseractEngine(Server.MapPath("~/tessdata"), "spa", EngineMode.Default)
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub byte_ServerClick(sender As Object, e As EventArgs)
        Try
            Dim texto As String
            Dim fileSize As Integer = imageFile.PostedFile.ContentLength
            Dim byteArray As Byte() = New Byte(fileSize - 1) {}
            imageFile.PostedFile.InputStream.Read(byteArray, 0, fileSize)

            Using engine = New TesseractEngine(Server.MapPath("~/tessdata"), "spa", EngineMode.Default)
                Using img = Pix.LoadFromMemory(byteArray)
                    Using page = engine.Process(img)
                        texto = page.GetText()
                        meanConfidenceLabel.InnerText = String.Format("{0:P}", page.GetMeanConfidence())
                        resultText.InnerText = page.GetText()
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    ' Puedes utilizar el objeto Bitmap como desees, por ejemplo, mostrarlo en una imagen en tu página web
    ' Por ejemplo, si tienes un control Image llamado imgResultado en tu página:
    'imgResultado.ImageUrl = "data:image/jpeg;base64," & Convert.ToBase64String(ImageToByteArray(bitmap), 0, ImageToByteArray(bitmap).Length)

End Class