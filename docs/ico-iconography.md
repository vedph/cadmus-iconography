# IconographyPart

This is just a draft. The plan is creating an item for each iconography, with an EID in its metadata part. The following properties describe the iconography proper, but they will probably be further split into parts to favor flexibility, reuse, and expansion.

- `subjects`\* (`string[]` 📚 `iconography-macro-subjects`, categories tree)
- `description` (`string`, MD, 5000)
- `relCitations` (`IcoRelCitation[]`):
  - `citations`\* (`string[]` via citation brick)
  - `tag` (`string`, 📚 `iconography-cit-tags`)
  - `note` (`string`, 1000)
- `relTexts` (`IcoRelText[]`):
  - `type`\* (`string` 📚 `iconography-txt-types`)
  - `tag` (`string` 📚 `iconography-txt-tags`)
  - `language`\* (`string` 📚 `iconography-txt-languages`)
  - `value` (`string`)
  - `note` (`string`, 1000)
- `features` (`string[]` flags: 📚 `iconography-features`): storie prime/seconde, etc.
- `contexts`  (`string[]`, 📚 `iconography-context-links`, categories tree): luoghi danteschi etc.
- `links` (`AssertedId[]`; see [AssertedCompositeIds](https://github.com/vedph/cadmus-bricks-shell-v3/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-ids)): to mss etc.
- `note` (`string`, 1000)
- `keywords` (`Keyword[]`):
  - `language`\* (`string` 📚 `iconography-key-languages`)
  - `value`\* (`string`)
