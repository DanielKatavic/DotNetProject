# DotNetProject
<h3>Project contains:</h3>
<ul>
  <li>Data layer (Class Library)</li>
  <li>Windows Forms application</li>
  <li>WPF application</li>
</ul>
<h3>Data layer:</h3>
<ul>   
  <li>Application gets data from API or local JSON files</li>
  <li>All data that Windows Forms and WPF applications are using is managed here 
</ul>
<h3>Windows Forms appliaction:</h3>
<ul>   
  <li>If user is starting app for the first time it asks him to select gender, language and favourite team</li>
  <li>First page:</li>
  <ul>
    <li>All players from selected team are listed as UserControls in FlowLayoutPanel</li>
  <li>User can add up to three favourite players by:</li> 
    <ul>
      <li>clicking on star which is part of UserControl</li>
      <li>right clicking on user control and selecting "add to favourite players"</li>
      <li>dragging-and-dropping one by one to FlowLayoutPanel</li>
      <li>holding ctrl + rmb and dragging-and-dropping multiple users to FlowLayoutPanel</li>
    </ul>
  </ul>
  <li>Second page:</li>
  <ul>
    <li>All players with yellow cards and goals are listed and ordered by descending</li>
    <li>User can print both of them by right clicking on FlowLayoutPanel and selecting "print"</li>
  </ul>
  <li>Third page:</li>
  <ul>
    <li>All matches of selected team are listed and ordered by descending</li>
    <li>User can print them by right clicking on FlowLayoutPanel and selecting "print"</li>
  </ul>
</ul>
<h3>WPF application:</h3>
<ul>   
  <li>Work in progress</li>
</ul>
