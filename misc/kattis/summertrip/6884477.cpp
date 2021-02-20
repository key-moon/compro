#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  int n = s.size();
  vector<int> lastInd(26, -1);
  vector<int> lastPossibleInd(n);
  for (int i = 0; i < n; i++) {
    var c = s[i] - 'a';
    if (0 <= lastInd[c]) {
      lastPossibleInd[lastInd[c]] = i - 1;
    }
    lastInd[c] = i;
  }
  for (int c = 0; c < 26; c++) {
    if (lastInd[c] < 0) continue;
    lastPossibleInd[lastInd[c]] = n - 1;
  }
  ll res = 0;
  lastInd = vector<int>(26, n);
  for (int i = n - 1; i >= 0; i--) {
    for (int c = 0; c < 26; c++) {
      if (lastInd[c] <= lastPossibleInd[i]) res++;
    }
    lastInd[s[i] - 'a'] = i;
  }
  cout << res << endl;
}
