<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarVoto.aspx.cs" Inherits="ClienteSOA.RegistrarVoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="well1">
          <div class="container">
            <h2>INGRESE LOS DATOS</h2>
            <form  id="FormularioLogin" runat="server" role="form" class="mailform off2">
              <input type="hidden" name="form-type" value="contact">
              <fieldset class="row">
                <label class="grid_4">

                    <asp:TextBox ID="Dpi_Votante" type="text" placeholder="Número DPI" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" 
                        ControlToValidate="Dpi_Votante"
                        runat="server" 
                        ErrorMessage="Campo Obligatorio"
                        ForeColor="Red" >                        
                    </asp:RequiredFieldValidator>              
                </label>
                <label class="grid_4">
                    <asp:TextBox type="text" ID="Codigo_Partido" placeholder="Codigo de Partido" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2"
                        ControlToValidate="Codigo_Partido"
                        runat="server" 
                        ErrorMessage="Campo Requerido"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </label>                                    
                  
                  <label class="grid_4">
                      <asp:Label ID="Ms_error1" name="Ms_error1" style="color:red" Visible="false" runat="server" Text=""></asp:Label>
                  </label>   
                 <div class="mfControls grid_12">                             
                    <asp:GridView ID="GridView1" Visible="true" runat="server"></asp:GridView>
                 </div>

               <div class="mfControls grid_12">
                    <asp:Button ID="BotonRegistrar" type="Button" runat="server" Text="REGISTRAR VOTO" class="btn" OnClick="BotonRegistrar_Click"/>                  
                </div>

              </fieldset>
            </form>
          </div>
        </section>

</asp:Content>
