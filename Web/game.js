// Complete browser version of Paperfold Studio idle clicker

const foldDisplay = document.getElementById('fold-display');
const rateDisplay = document.getElementById('rate-display');
const foldButton = document.getElementById('fold-button');
const hireAssistantButton = document.getElementById('hire-assistant-button');
const assistantInfo = document.getElementById('assistant-info');
const factoryInfo = document.getElementById('factory-info');
const buyFactoryButton = document.getElementById('buy-factory-button');
const setList = document.getElementById('set-list');
const skillList = document.getElementById('skill-list');
const achievementList = document.getElementById('achievement-list');
const skillPointsEl = document.getElementById('skill-points');
const prestigeInfo = document.getElementById('prestige-info');
const prestigeButton = document.getElementById('prestige-button');
const saveButton = document.getElementById('save-button');
const loadButton = document.getElementById('load-button');
const paper = document.getElementById('paper');
const gameContainer = document.getElementById('game-container');

let foldCount = 0;
let foldsPerClick = 1;
let assistantLevel = 0;
const baseAssistantCost = 10;
let baseFoldsPerSecond = 1;
let skillPoints = 0;
let prestigeCount = 0;
const prestigeBonus = 0.1;

let factoryLevel = 0;
const baseFactoryCost = 1000;
let factoryFoldsPerSecond = 5;

let achievements = [
  { name: 'First Fold', achieved: false, check: () => foldCount >= 1 },
  { name: '100 Folds', achieved: false, check: () => foldCount >= 100 },
  { name: 'First Assistant', achieved: false, check: () => assistantLevel >= 1 },
  { name: 'First Factory', achieved: false, check: () => factoryLevel >= 1 },
  { name: 'Prestigious', achieved: false, check: () => prestigeCount >= 1 }
];

let origamiSets = [
  { name: 'Crane Set', cost: 100, completed: false },
  { name: 'Flower Set', cost: 500, completed: false },
  { name: 'Star Set', cost: 1000, completed: false },
  { name: 'Dragon Set', cost: 5000, completed: false },
  { name: 'Animal Set', cost: 10000, completed: false },
  { name: 'Mythical Set', cost: 50000, completed: false },
  { name: 'Master Set', cost: 250000, completed: false }
];

let skills = [
  { name: 'Faster Assistants', cost: 1, purchased: false },
  { name: '+1 Fold/Click', cost: 1, purchased: false },
  { name: 'Auto-fold', cost: 3, purchased: false },
  { name: 'Better Paper', cost: 5, purchased: false },
  { name: 'Factory Efficiency', cost: 10, purchased: false },
  { name: 'Double Click Power', cost: 10, purchased: false },
  { name: 'Assistant Manager', cost: 20, purchased: false },
  { name: 'Factory Manager', cost: 20, purchased: false }
];

function assistantCost() {
  return Math.ceil(baseAssistantCost * Math.pow(1.15, assistantLevel));
}

function factoryCost() {
  return Math.ceil(baseFactoryCost * Math.pow(1.2, factoryLevel));
}

function foldsPerSecond() {
  const assistantRate = assistantLevel * baseFoldsPerSecond;
  const factoryRate = factoryLevel * factoryFoldsPerSecond;
  return (assistantRate + factoryRate) * (1 + prestigeCount * prestigeBonus);
}

function updateDisplay() {
  foldDisplay.textContent = `Folds: ${Math.floor(foldCount)}`;
  rateDisplay.textContent = `Folds/s: ${foldsPerSecond().toFixed(1)}`;
  assistantInfo.textContent = `Level: ${assistantLevel} (${foldsPerSecond().toFixed(1)}/s) - Cost: ${assistantCost()}`;
  factoryInfo.textContent = `Level: ${factoryLevel} (${(factoryLevel * factoryFoldsPerSecond).toFixed(1)}/s) - Cost: ${factoryCost()}`;
  skillPointsEl.textContent = skillPoints;
  prestigeInfo.textContent = `Prestige count: ${prestigeCount}`;

  // Update sets
  setList.innerHTML = '';
  origamiSets.forEach(set => {
    const li = document.createElement('li');
    li.textContent = set.completed ? `${set.name} - Completed` : `${set.name} - Cost: ${set.cost}`;
    setList.appendChild(li);
  });

  // Update skills
  skillList.innerHTML = '';
  skills.forEach((skill, index) => {
    const li = document.createElement('li');
    const btn = document.createElement('button');
    btn.textContent = skill.purchased ? `${skill.name} (Purchased)` : `${skill.name} - Cost: ${skill.cost}`;
    btn.disabled = skill.purchased || skillPoints < skill.cost;
    btn.addEventListener('click', () => purchaseSkill(index));
    li.appendChild(btn);
    skillList.appendChild(li);
  });

  // Update achievements
  achievementList.innerHTML = '';
  achievements.forEach(ach => {
    const li = document.createElement('li');
    li.textContent = ach.name;
    if (ach.achieved) li.classList.add('unlocked');
    achievementList.appendChild(li);
  });
}

function addFold(amount) {
  foldCount += amount;
  updateDisplay();
}

function purchaseSkill(index) {
  const skill = skills[index];
  if (!skill || skill.purchased) return;
  if (skillPoints >= skill.cost) {
    skillPoints -= skill.cost;
    skill.purchased = true;
    if (skill.name === 'Faster Assistants') {
      baseFoldsPerSecond += 0.5;
    } else if (skill.name === '+1 Fold/Click') {
      foldsPerClick += 1;
    } else if (skill.name === 'Auto-fold') {
      baseFoldsPerSecond += 1;
    } else if (skill.name === 'Better Paper') {
      foldsPerClick *= 2;
    } else if (skill.name === 'Factory Efficiency') {
      factoryFoldsPerSecond += 2;
    } else if (skill.name === 'Double Click Power') {
      foldsPerClick *= 2;
    } else if (skill.name === 'Assistant Manager') {
      baseFoldsPerSecond += 2;
    } else if (skill.name === 'Factory Manager') {
      factoryFoldsPerSecond += 3;
    }
    updateDisplay();
  }
}

function checkSets() {
  origamiSets.forEach(set => {
    if (!set.completed && foldCount >= set.cost) {
      set.completed = true;
      skillPoints += 1;
    }
  });
}

function checkAchievements() {
  achievements.forEach(ach => {
    if (!ach.achieved && ach.check()) {
      ach.achieved = true;
    }
  });
}

function hireAssistant() {
  const cost = assistantCost();
  if (foldCount >= cost) {
    foldCount -= cost;
    assistantLevel += 1;
    updateDisplay();
  }
}

function buyFactory() {
  const cost = factoryCost();
  if (foldCount >= cost) {
    foldCount -= cost;
    factoryLevel += 1;
    updateDisplay();
  }
}

function prestige() {
  prestigeCount += 1;
  foldCount = 0;
  skillPoints = 0;
  assistantLevel = 0;
  factoryLevel = 0;
  baseFoldsPerSecond = 1;
  foldsPerClick = 1;
  origamiSets.forEach(set => set.completed = false);
  skills.forEach(skill => skill.purchased = false);
  updateDisplay();
}

function tick() {
  addFold(foldsPerSecond());
  checkSets();
  checkAchievements();
}

function saveGame() {
  const data = {
    foldCount,
    foldsPerClick,
    assistantLevel,
    baseFoldsPerSecond,
    factoryLevel,
    factoryFoldsPerSecond,
    skillPoints,
    prestigeCount,
    origamiSets,
    skills,
    achievements
  };
  localStorage.setItem('paperfold-save', JSON.stringify(data));
}

function loadGame() {
  const saved = localStorage.getItem('paperfold-save');
  if (!saved) return;
  try {
    const data = JSON.parse(saved);
    foldCount = data.foldCount || 0;
    foldsPerClick = data.foldsPerClick || 1;
    assistantLevel = data.assistantLevel || 0;
    baseFoldsPerSecond = data.baseFoldsPerSecond || 1;
    factoryLevel = data.factoryLevel || 0;
    factoryFoldsPerSecond = data.factoryFoldsPerSecond || 5;
    skillPoints = data.skillPoints || 0;
    prestigeCount = data.prestigeCount || 0;
    origamiSets = data.origamiSets || origamiSets;
    skills = data.skills || skills;
    achievements = data.achievements || achievements;
  } catch (e) {
    console.error('Failed to load save', e);
  }
  updateDisplay();
}

function dailyBonus() {
  const today = new Date().toDateString();
  const last = localStorage.getItem('paperfold-lastbonus');
  if (today !== last) {
    foldCount += 50;
    localStorage.setItem('paperfold-lastbonus', today);
    alert('Daily bonus! +50 folds');
  }
}

// Event wiring
foldButton.addEventListener('click', (e) => {
  addFold(foldsPerClick);

  // Position the paper at the mouse click location
  const rect = gameContainer.getBoundingClientRect();
  const x = e.clientX - rect.left - paper.offsetWidth / 2;
  const y = e.clientY - rect.top - paper.offsetHeight / 2;
  paper.style.left = `${x}px`;
  paper.style.top = `${y}px`;

  paper.classList.remove('fold');
  // Trigger reflow to restart animation
  void paper.offsetWidth;
  paper.classList.add('fold');
});

hireAssistantButton.addEventListener('click', hireAssistant);
buyFactoryButton.addEventListener('click', buyFactory);
prestigeButton.addEventListener('click', prestige);
saveButton.addEventListener('click', () => {
  saveGame();
  alert('Game saved!');
});
loadButton.addEventListener('click', () => {
  loadGame();
  alert('Game loaded!');
});

document.addEventListener('DOMContentLoaded', () => {
  loadGame();
  dailyBonus();
  updateDisplay();
  setInterval(tick, 1000);
});
