// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2708/judge/4895893/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 > void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 > void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  string s;
  cin >> s;
  s = "##" + s + "##";
  while (2 + 3 + 2 < s.size()){
    bool isA = true;
    bool isB = true;
    bool isC = true;
    for (int i = 0; i < (int)s.size(); i++){
      switch (s[i]){
      case 'A':
	if (s[i + 1] != 'B' || s[i + 2] != 'C') isA = false;
	break;
      case 'B':
	if (s[i - 1] != 'A' || s[i + 1] != 'C') isB = false;
	break;
      case 'C':
	if (s[i - 2] != 'A' || s[i - 1] != 'B') isC = false;
	break;
      }
    }

    char target = isA ? 'A' : isB ? 'B' : isC ? 'C' : '#';
    if (target == '#') goto imp;

    int sz = (int)s.size();
    string news = "";
    for (int i = 0; i < sz; i++){
      if (i < sz - 2 && s[i] == 'A' && s[i + 1] == 'B' && s[i + 2] == 'C'){
	news += target;
	i += 2;
	continue;
      }
      news += s[i];
    }
    //cout << s << endl;
    s = news;
    if (sz == (int)s.size()) break;
  }
  //cout << s << endl;
  if (s != "##ABC##") goto imp;
  cout << "Yes" << endl;
  return 0;
 imp:;
  cout << "No" << endl;
}

