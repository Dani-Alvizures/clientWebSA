<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarMesa.aspx.cs" Inherits="ClienteSOA.ConsultarMesa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="well1">
          <div class="container">
            <h2>INGRESE LOS DATOS</h2>
            <form  id="FormularioLogin" runat="server" role="form" class="mailform off2">
              <input type="hidden" name="form-type" value="contact">
              <fieldset class="row">
                <label class="grid_4">

                    <asp:TextBox ID="Numero_DPI" type="text" placeholder="Numero de DPI" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2"
                        ControlToValidate="Numero_DPI"
                        runat="server" 
                        ErrorMessage="Campo Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </label>
                  
                  
                  <label class="grid_4">
                      <asp:Label ID="Ms_error1" name="Ms_error1" style="color:red" Visible="false" runat="server" Text=""></asp:Label>
                  </label>                              
          
                  <div class="mfControls grid_12">
                      <asp:GridView ID="TablaDatos" runat="server"></asp:GridView>
                      </div>

               <div class="mfControls grid_12">
                    <asp:Button ID="ConsultarVarios" type="Button" runat="server" Text="CONSULTAR VARIOS" class="btn" OnClick="BotonEnviar_Click"  />                  
                </div>

              </fieldset>
            </form>
          </div>
        </section>

</asp:Content>
