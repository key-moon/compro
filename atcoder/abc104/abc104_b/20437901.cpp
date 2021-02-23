// detail: https://atcoder.jp/contests/abc104/submissions/20437901
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
  var flag = true;
  flag &= s[0] == 'A';
  int cnt = 0;
  int ind = 0;
  for (int i = 2; i < s.size() - 1; i++) {
    if (s[i] == 'C') {
      cnt++;
      ind = i;
    }
  }
  flag &= cnt == 1;
  for (int i = 1; i < s.size(); i++) {
    if (i == ind) continue;
    if (s[i] < 'a' || 'z' < s[i]) flag &= false;
  }
  cout << (flag ? "AC" : "WA") << endl;
}
