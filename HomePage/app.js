// Handle the form submission
document.getElementById('configForm').addEventListener('submit', function(event) {
    event.preventDefault();  // Prevent the default form submission
  
    // Get values from the input fields
    const playFabTitleId = document.getElementById('playFabTitleId').value;
    const playFabApiKey = document.getElementById('playFabApiKey').value;
    const defaultBanDuration = document.getElementById('defaultBanDuration').value;
  
    // Create an object to hold the configuration
    const config = {
        playFabTitleId: playFabTitleId,
        playFabApiKey: playFabApiKey,
        defaultBanDuration: parseInt(defaultBanDuration, 10)
    };
  
    // Save the configuration to localStorage (or send to backend)
    localStorage.setItem('config', JSON.stringify(config));
  
    // Display a success message
    document.getElementById('statusMessage').textContent = 'Configuration saved successfully!';
    
    // Optionally, send config to backend to save it in config.json (this is not included here)
  });
  