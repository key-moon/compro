// detail: https://atcoder.jp/contests/agc016/submissions/20445651
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
  int res = INT_MAX;
  for (char c = 'a'; c <= 'z'; c++) {
    var t = s;
    int op = 0;
    while (1 < t.size()) {
      if (count(t.begin(), t.end(), c) == t.size()) break;
      string newt = "";
      for (int i = 1; i < t.size(); i++) {
        if (t[i - 1] == c || t[i] == c) newt += c;
        else newt += '#';
      }
      t = newt;
      op++;
    }
    chmin(res, op);
  }
  cout << res << endl;
}
