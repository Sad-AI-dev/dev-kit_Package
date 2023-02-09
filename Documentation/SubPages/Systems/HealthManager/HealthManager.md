### [found in: HealthManagerSystem](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/HealthManager/HealthManagerSystem.md)
## Health Manager
The Health Manager handles health, healing, taking damage and death. Can show it through a healthbar.  
It has the following features:

- **Health** *float*  
Determines the health the object starts with.
- **Max Health** *float*  
Determines the maximum health. If set to 0 or lower, *health* will be used as maximum health.

- **Hit On Death** *bool*  
When set to *true*, *OnHit* event will be invoked when *OnDeath* is invoked. When set to *false*, does nothing.

- **Allow Over Heal** *bool*  
When set to *true*, the object's health is allowed to surpass max health. When set to *false*, does nothing.

- **Allow Neg Damage** *bool*  
When set to *true*, the object is allowed to heal through taking negative damage values. When set to *false*, object cannot take less then 0 damage.

- **Allow Neg Heal** *bool*  
When set to *true*, the object is allowed to take damage through healing negative healing values.  When set to *false*, object cannot heal less then 0.

- **On Hit** *UnityEvent\<float\>*  
Will be invoked when damage is taken. Will *not* be invoked when the damage resulst in death, unless *Hit On Death* is set to *true*.  
Passes the amount of damage taken as a float parameter.

- **On Heal** *UnityEvent\<float\>*  
Will be invoked when object is healed. Passes the amount healed as a float parameter.

- **On Death** *UnityEvent*  
Will be invoked when damage taken results in health reaching 0 or lower.

It has the following functions:

- **TakeDamage**(damage *float*)  
Used to deal damage to the object.

- **Heal**(toHeal *float*)  
Used to heal the object.