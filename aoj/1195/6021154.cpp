// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1195/judge/6021154/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

bool solve() {
  string s;
  cin >> s;
  if (s == "#") return false;

  int n = s.size();

  var is_valid = [&](string& plain) {
    vector<bool> used(26);
    for (int i = 0; i < plain.size(); i++) {
      var expected = s[i];
      var actual = plain[i];
      if (actual != 'a' && not used[actual - 'a']) {
        used[actual - 'a'] = true;
        actual--;
      }
      if (expected != actual) return false;
    }
    return true;
  };

  vector<string> valid{};
  for (int b = 0; b < (1 << n); b++) {
    string plain = s;
    for (int i = 0; i < n; i++) {
      if (b >> i & 1) {
        if (plain[i] == 'z') goto invalid;
        plain[i]++;
      }
    }
    if (is_valid(plain)) {
      valid.emplace_back(plain);
    }
  invalid:;
  }
  sort(valid.begin(), valid.end());

  cout << valid.size() << endl;

  for (int i = 0; i < valid.size(); i++) {
    if (i < 5 || valid.size() <= i + 5) {
      cout << valid[i] << endl;
    }
  }

  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve()){}
}


