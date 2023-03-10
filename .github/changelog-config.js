module.exports = {
  types: [
    { types: ["feat", "feature"], label: "๐ New Features" },
    { types: ["fix", "bugfix"], label: "๐ Bug Fixes" },
    { types: ["improvements", "enhancement", "imp"], label: "๐  Improvements" },
    { types: ["perf"], label: "โก๏ธ Performance Improvements" },
    { types: ["build", "ci"], label: "๐ฆ Build System" },
    { types: ["refactor"], label: "โป๏ธ Refactors" },
    { types: ["doc", "docs"], label: "๐ Documentation Changes" },
    { types: ["test", "tests"], label: "๐งช Tests" },
    { types: ["breaking"], label: "๐จ Breaking Changes" },
    { types: ["style"], label: "๐จ Code Style Changes" },
    { types: ["chore"], label: "๐งน Chores" },
    { types: ["security"], label: "๐ Security"},
    { types: ["other"], label: "Other Changes" },
  ],

  excludeTypes: ["other"],

  renderTypeSection: function (label, commits) {
    let text = `\n## ${label}\n`;

    commits.forEach((commit) => {
      text += `- ${commit.subject}\n`;
    });

    return text;
  },

  renderChangelog: function (release, changes) {
    return changes;
  },
};