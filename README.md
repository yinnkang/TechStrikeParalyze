# TechStrikeParalyze

Phoenix Point mod that replaces Technician Arms' Shock/Stun damage with configurable Base + Piercing + Paralysing damage.

## Configuration

### Damage Values
- **Base Damage** (default: 10) - Standard damage component
- **Piercing Damage** (default: 40) - Armor penetration  
- **Paralysing Damage** (default: 30) - Paralysis effect (replaces Shock/Stun)
- **Enable Toggle** - Master on/off switch

### Usage
1. Enable mod in Phoenix Point Mods menu
2. Adjust values in mod settings (main menu only)
3. Changes apply immediately to all Technician Arms

## Technical Details

- Targets weapon: `NJ_Technician_MechArms_WeaponDef`
- Replaces `ShockKeyword` with `DamageKeyword` + `PiercingKeyword` + `ParalysingKeyword`
- Fixes 18x damage multiplier bug from incorrect damage keyword usage
- Safe to enable/disable mid-campaign

## Installation

Extract to `Documents/My Games/Phoenix Point/Mods/` directory.

## Build

Requires ModSDK in parent directory. Output in `Dist/` folder.