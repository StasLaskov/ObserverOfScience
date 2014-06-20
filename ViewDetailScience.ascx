<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewDetailScience.ascx.cs" Inherits="ObserverOfScience.ViewDetailScience" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
		
		
<script src="/DesktopModules/ObserverOfScience/three/build/three.min.js"></script>
<script src="/DesktopModules/ObserverOfScience/three/examples/js/libs/stats.min.js"></script>
<h1 align="center" class="DetailName"><asp:Label ID="lblDetailName" runat="server"/></h1>
<div align="left"><b>Статус разработки:</b> <i><asp:Label ID="lblDetailStatus" runat="server" CssClass="Normal"/></i></div>
<div align="left"><i><asp:Label ID="lblYearOfCreation" runat="server" CssClass="Normal"/></i></div><br/>

<table width="50%" class="DetailInvention">

	<tr valign="top">
		<td rowspan="2" style="width:20%;">
		
		<div style="overflow:auto;">
		<asp:Label runat="server" id="lblResources"/>
		<asp:Repeater runat="server" id="RepeaterResources" OnItemDataBound="Rpt_Resource">
		<ItemTemplate>
		
			<asp:Image id="ImgResource" runat="server" Height="20px" Width="20px"/>
			<asp:HyperLink id="HyperResource" runat="server">
			</asp:HyperLink>
		
		</ItemTemplate>
		</asp:Repeater>
		</div>
		
		</td>
		<td colspan="2" rowspan="3" align="center" >
		<div id="container" style="Width:460px; Height:300px;"></div>
		<script>

			var container, stats;
			var camera, scene, renderer;
			var group;
			var mouseX = 0, mouseY = 0;

			var windowHalfX = window.innerWidth / 2;
			var windowHalfY = window.innerHeight / 2;

			init();
			animate();

			function init() {

				container = document.getElementById( 'container' );

				camera = new THREE.PerspectiveCamera( 60, window.innerWidth / window.innerHeight, 1, 10000 );
				camera.position.z = 500;

				scene = new THREE.Scene();

				group = new THREE.Object3D();
				scene.add( group );

				// earth

				var earthTexture = new THREE.Texture();
				var loader = new THREE.ImageLoader();

				loader.addEventListener( 'load', function ( event ) {

					earthTexture.image = event.content;
					earthTexture.needsUpdate = true;

				} );

				loader.load( '/DesktopModules/ObserverOfScience/three/examples/textures/land_ocean_ice_cloud_2048.jpg' );

				var geometry = new THREE.SphereGeometry( 200, 20, 20 );
				var material = new THREE.MeshBasicMaterial( { map: earthTexture, overdraw: true } );

				var mesh = new THREE.Mesh( geometry, material );
				group.add( mesh );

				// shadow
			
				var canvas = document.createElement( 'canvas' );
				canvas.width = 128;
				canvas.height = 128;

				var context = canvas.getContext( '2d' );
				var gradient = context.createRadialGradient( canvas.width / 2, canvas.height / 2, 0, canvas.width / 2, canvas.height / 2, canvas.width / 2 );
				gradient.addColorStop( 0.1, 'rgba(210,210,210,1)' );
				gradient.addColorStop( 1, 'rgba(255,255,255,1)' );

				context.fillStyle = gradient;
				context.fillRect( 0, 0, canvas.width, canvas.height );

				var texture = new THREE.Texture( canvas );
				texture.needsUpdate = true;

				var geometry = new THREE.PlaneGeometry( 300, 300, 3, 3 );
				var material = new THREE.MeshBasicMaterial( { map: texture, overdraw: true } );

				var mesh = new THREE.Mesh( geometry, material );
				mesh.position.y = - 250;
				mesh.rotation.x = - Math.PI / 2;
				group.add( mesh );

				renderer = new THREE.CanvasRenderer();
				renderer.setSize( 460, 300 );

				container.appendChild( renderer.domElement );

				

				document.addEventListener( 'mousemove', onDocumentMouseMove, false );

				//

				window.addEventListener( 'resize', onWindowResize, false );

			}

			function onWindowResize() {

				windowHalfX = window.innerWidth / 2;
				windowHalfY = window.innerHeight / 2;

				camera.aspect = 460 / 300;
				camera.updateProjectionMatrix();

				renderer.setSize(460, 300 );

			}

			function onDocumentMouseMove( event ) {

				mouseX = ( event.clientX - windowHalfX );
				mouseY = ( event.clientY - windowHalfY );

			}

			//

			function animate() {

				requestAnimationFrame( animate );

				render();
				stats.update();

			}

			function render() {

				camera.position.x += ( mouseX - camera.position.x ) * 0.05;
				camera.position.y += ( - mouseY - camera.position.y ) * 0.05;
				camera.lookAt( scene.position );

				group.rotation.y -= 0.005;

				renderer.render( scene, camera );

			}


		</script>
		
		
		</td>
		<td rowspan="4" align="justify" style="width:30%;">
		<div style="overflow:auto; margin:4px 5px; 0 6px;"><asp:Label ID="lblDetailInventionEssence" runat="server"/></div>
		</td>
	</tr>

	<tr> </tr>
	<tr>
		<td rowspan="2" style="width:20%;"><div style="overflow:auto;margin:4px 5px; 0 6px;">
		<asp:Label ID="lblDetailScientist" runat="server"/></div></td>
	</tr>
	<tr>
		<td  colspan="2" align="justify" style="width:50%;">
		<div style="overflow:auto;margin:4px 5px; 0 6px;"><asp:Label ID="lblAdvantages" runat="server"/></div></td>
	</tr>
	<tr>
		<td style="width:20%;">
		<div style="overflow:auto;margin:4px 5px; 0 6px;">
		<asp:Label id="lblPatent" runat="server"></asp:Label>
		
		<asp:Repeater runat="server" id="RepeaterPatent" OnItemDataBound="Rpt_Patent">
		<ItemTemplate>
		
			
			
			<asp:HyperLink id="HyperPatent" runat="server" ></asp:HyperLink>
			<asp:Label id="lblDatePatent" runat="server"></asp:Label>
		
		</ItemTemplate>
		</asp:Repeater>
		</div> 
		</td>
		
		<td colspan="2" style="width:50%;"><div style="overflow:auto;">
		
		
		<asp:Repeater runat="server" id="RepeaterTerms" OnItemDataBound="Rpt_Terms">
		<ItemTemplate>
		
			<div style="overflow:auto;margin:4px 5px; 0 6px;">
			<b><asp:Label id="VocabularyName" runat="server"/></b>
			<i><asp:HyperLink id="HyperTerms" runat="server" ></asp:HyperLink></i></div> 
		
		</ItemTemplate>
		</asp:Repeater>
		
		</div></td>
		<td style="width:30%;"><div style="overflow:auto;"><asp:Label runat="server" id="lblIntroduction"/><asp:HyperLink id="HyperIntroduction" runat="server"></asp:HyperLink><asp:Label id="YearIntroduction" runat="server"/></div></td>
	</tr>
</table>
	
	
