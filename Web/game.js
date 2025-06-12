// ...Game logic for Paperfold Studio Web clicker
const foldDisplay = document.getElementById('fold-display');
const foldButton = document.getElementById('fold-button');
const saveButton = document.getElementById('save-button');
const loadButton = document.getElementById('load-button');

let foldCount = 0;
const foldsPerClick = 1;

function updateDisplay() {
  foldDisplay.textContent = `Folds: ${foldCount}`;
}

// Load on start if save exists
document.addEventListener('DOMContentLoaded', () => {
  const saved = localStorage.getItem('foldCount');
  if (saved !== null) {
    foldCount = parseInt(saved, 10);
  }
  updateDisplay();
});

foldButton.addEventListener('click', () => {
  foldCount += foldsPerClick;
  updateDisplay();
});

saveButton.addEventListener('click', () => {
  localStorage.setItem('foldCount', foldCount);
  alert('Game saved!');
});

loadButton.addEventListener('click', () => {
  const saved = localStorage.getItem('foldCount');
  if (saved !== null) {
    foldCount = parseInt(saved, 10);
    updateDisplay();
    alert('Game loaded!');
  } else {
    alert('No save found.');
  }
});
