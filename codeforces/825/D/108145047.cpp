// detail: https://codeforces.com/contest/825/submission/108145047
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  string t;
  cin >> t;
  int wildcard = 0;
  vector<int> sCnts(26);
  for (var&& c : s) {
    if (c == '?') wildcard++;
    else sCnts[c - 'a']++;
  }

  vector<int> tCnts(26);
  for (var&& c : t) {
    tCnts[c - 'a']++;
  }

  int score = 0;
  while (true) {
    int over = 0;
    for (int i = 0; i < 26; i++) {
      over += max(tCnts[i] * score - sCnts[i], 0);
    }
    if (over > wildcard) {
      score--;
      break;
    }
    score++;
  }
  stack<char> wildcards{};
  for (int i = 0; i < 26; i++) {
    var over = max(tCnts[i] * score - sCnts[i], 0);
    for (int j = 0; j < over; j++) wildcards.push('a' + i);
  }
  while (wildcards.size() < wildcard) wildcards.push('a');
  for (var&& c : s) {
    if (c == '?') {
      c = wildcards.top(); wildcards.pop();
    }
  }
  cout << s << endl;
}
