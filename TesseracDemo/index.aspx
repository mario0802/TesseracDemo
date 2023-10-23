<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="TesseracDemo.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>Tesserac Demo</h1>
    <form id="Form1" method="post" role="form" runat="server">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        <fieldset>
            <legend>File Upload</legend>
            <div class="form-group">
                <label for="imageFile" runat="server">File:</label>
                <input class="form-control" type="file" id="imageFile" runat="server" onchange="mostrarImagen()" />
                <span class="help-block">The file to be processed.</span>
            </div>
            <button id="submitFile" type="submit" class="btn btn-default" onserverclick="submitFile_ServerClick" runat="server">Archivo servidor</button>

            <button id="bitMap" type="submit" class="btn btn-default" onserverclick="bitMap_ServerClick" runat="server">Bitmap</button>

            <button id="byte" type="submit" class="btn btn-default" onserverclick="byte_ServerClick" runat="server">Bytes array</button>

            <button id="googleVision" type="submit" class="btn btn-default" onserverclick="googleVision_ServerClick" runat="server">Google Vision</button>
        </fieldset>

        <fieldset>
            <legend>OCR Results</legend>
            <div class="form-group">
                <label for="result" runat="server">Mean Confidence:</label>
                <label class="form-control" id="meanConfidenceLabel" runat="server" />
            </div>
            <div class="form-group">
                <label for="result" runat="server">Result:</label>
                <textarea class="form-control" rows="10" id="resultText" readonly="readonly" runat="server"></textarea>
            </div>
        </fieldset>

        <fieldset>
            <legend>Imagen</legend>
            <img src="" id="img" width="400" />
        </fieldset>

        <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>

    <script>
        function mostrarImagen() {
            const fileInput = document.getElementById('imageFile');
            const imagenMostrada = document.getElementById('img');

            if (fileInput.files && fileInput.files[0]) {
                const archivo = fileInput.files[0];
                const reader = new FileReader();

                reader.onload = function (e) {
                    const bitmapUrl = e.target.result;
                    // Crea una nueva imagen y establece su fuente como el Bitmap
                    const imagenBitmap = new Image();
                    imagenBitmap.src = bitmapUrl;
                    // Asigna la imagen Bitmap a la etiqueta <img> en la página
                    imagenMostrada.src = imagenBitmap.src;
                };
                reader.readAsDataURL(archivo);
            }
        }
    </script>
</body>
</html>
