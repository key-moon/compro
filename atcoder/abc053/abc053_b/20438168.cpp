// detail: https://atcoder.jp/contests/abc053/submissions/20438168
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
  int fst = 0;
  for (int i = 0; i < s.size(); i++) {
    if (s[i] == 'A') {
      fst = i;
      break;
    }
  }
  int lst = 0;
  for (int i = s.size() - 1; i >= 0; i--) {
    if (s[i] == 'Z') {
      lst = i;
      break;
    }
  }
  cout << lst - fst + 1 << endl;
}
