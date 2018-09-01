<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasivaRegistraVotos.aspx.cs" Inherits="ClienteSOA.CargaMasivaRegistraVotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <section class="well1">
          <div class="container">
            <h2>INGRESE LOS DATOS</h2>
            <form  id="FormularioLogin" runat="server" role="form" class="mailform off2">
              <input type="hidden" name="form-type" value="contact">
              <fieldset class="row">
                <label class="grid_4">

                    <asp:TextBox ID="CargaM" type="text" TextMode="MultiLine" placeholder="Ingrese la Cadena JSon" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2"
                        ControlToValidate="CargaM"
                        runat="server" 
                        ErrorMessage="Campo Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </label>                           
              
              
                  <div class="mfControls grid_12">
                      <asp:GridView ID="TablaDatos" runat="server"></asp:GridView>
                      </div>

               <div class="mfControls grid_12">
                    <asp:Button ID="RealizarCarga" type="Button" runat="server" Text="REALIZAR CARGA" class="btn" OnClick="RealizarCarga_Click"/>                  
                </div>

              </fieldset>
            </form>
          </div>
        </section>

</asp:Content>
